using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace CustomSerialization
{
    public class CustomSerializer: IFormatter
    {
        // Variables
        private Type _type;

        // Constructor
        public CustomSerializer(Type type)
        {
            _type = type;
        }

        // Functions
        public void Serialize(Stream serializationStream, Object graph)
        {
            // Get the list of properties
            List<PropertyInfo> propertyInfos = _type.GetProperties().ToList();
            
            // Stream writer so we can write the type name
            StreamWriter streamWriter = new StreamWriter(serializationStream);

            // Write the type name
            streamWriter.WriteLine(_type.Name);
            
            // Write the property names and values
            foreach (var info in propertyInfos)
            {
                streamWriter.WriteLine($"{info.Name}:{info.GetValue(graph)}");
            }
            
            // Flush the stream writer to save changes
            streamWriter.Flush();

        }
        
        public object Deserialize(Stream serializationStream)
        {
            Object obj = Activator.CreateInstance(_type);

            using (var streamReader = new StreamReader(serializationStream))
            {
                // To read the type name
                string typeName = streamReader.ReadLine();

                // Read the rest of contents
                string contents = streamReader.ReadToEnd();
                
                // Create the list that contains the string pairs
                List<string> pairs = contents.Split(new string[] {"\n", "\r\n"}, StringSplitOptions.RemoveEmptyEntries).ToList();
                string key, value;
                
                // Now for each pair add the key and value
                foreach (var pair in pairs)
                {
                    // Adding separation
                    string[] keyValue = pair.Split(':');
                    key = keyValue[0];
                    value = keyValue[0];

                    // Get the property info that has this key
                    PropertyInfo propertyInfo = _type.GetProperty(key);
                    
                    // if it has the key
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(obj, value, null); // Not an array so the index will be null
                    }
                }
            }

            return obj;
        }

        // Getters and Setters
        public ISurrogateSelector SurrogateSelector { get; set; }
        public SerializationBinder Binder { get; set; }
        public StreamingContext Context { get; set; }
    }
}