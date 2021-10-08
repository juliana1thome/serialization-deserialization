using System;
using System.IO;

namespace CustomSerialization
{
    // It will serialize the data and deserialize it too
    public class DataSerializer
    {
        public void CustomSerialized(Type dataType, object data, string filePath)
        {
            var customSerializer = new CustomSerializer(dataType);

            // If this file exist delete it and create a new one
            if (File.Exists(filePath)) File.Delete(filePath);

            // Now create the File Stream
            FileStream fileStream = File.Create(filePath);

            // Serialize this file that you created / The data is the data that will be serialized
            customSerializer.Serialize(fileStream, data);

            // Don't forget to close it
            fileStream.Close();
        }

        public object CustomDeserialize(Type dataType, string filePath)
        {
            object obj = null;

            var customSerializer = new CustomSerializer(dataType);

            // Same thing the file exists open it
            // and read it after make the object be a deserialized file, and close the file stream
            if (File.Exists(filePath))
            {
                var fileStream = File.OpenRead(filePath);
                obj = customSerializer.Deserialize(fileStream);
                fileStream.Close();
            }

            return obj;
        }
    }
}