using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BinarySerialization
{
    // It will serialize the data and deserialize it too
    public class DataSerializer
    {
        public void BinarySerialized(object data, string filePath)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
         
            // If this file exist delete it and create a new one
            if (File.Exists(filePath)) File.Delete(filePath);
            
            // Create a variable called fileStream(that is a FileStream),
            // which will be created in the filePath from the file deleted
            var fileStream = File.Create(filePath);
            
            // Serialize this file that you created / The data is the data that will be serialized
            binaryFormatter.Serialize(fileStream, data);
            
            // Don't forget to close it
            fileStream.Close();
        }

        public object BinaryDeserialize(string filePath)
        {
            object obj = null;

            FileStream fileStream;
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            // Same thing the file exists open it
            // and read it after make the object be a deserialized file, and close the file stream
            if (File.Exists(filePath))
            {
                fileStream = File.OpenRead(filePath);
                obj = binaryFormatter.Deserialize(fileStream);
                fileStream.Close();
            }
            
            return obj;
        }
    }
}