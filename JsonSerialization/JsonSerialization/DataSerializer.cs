using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonSerialization
{
    // It will serialize the data and deserialize it too
    public class DataSerializer
    {
        public void JsonSerialized(object data, string filePath)
        {
            JsonSerializer jsonSerializer = new JsonSerializer();

            // If this file exist delete it and create a new one
            if (File.Exists(filePath)) File.Delete(filePath);

            // Now create the text writer that will be a new stream writer that has the file path
            StreamWriter streamWriter = new StreamWriter(filePath);

            // Create the JSON writer
            JsonWriter jsonWriter = new JsonTextWriter(streamWriter);
            
            // Serializing the data, with the json writer
            jsonSerializer.Serialize(jsonWriter, data);
                
            // Don't forget to close it
            jsonWriter.Close();
            streamWriter.Close();
        }

        public object JsonDeserialize(Type dataType, string filePath)
        {
            JObject jObject = null;
 
            var jsonSerializer = new JsonSerializer();

            // Same thing the file exists open it
            // and read it after make the object be a deserialized file, and close the file stream
            if (File.Exists(filePath))
            {
                var streamReader = new StreamReader(filePath);
                JsonReader jsonReader = new JsonTextReader(streamReader);
                // Don't forget to cast it to be a JObject
                jObject = jsonSerializer.Deserialize(jsonReader) as JObject;
                jsonReader.Close();
            }

            return jObject.ToObject(dataType);
        }
    }
}