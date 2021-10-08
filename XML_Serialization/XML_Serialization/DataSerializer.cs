using System;
using System.IO;
using System.Xml.Serialization;

namespace XML_Serialization
{
// It will serialize the data and deserialize it too
    public class DataSerializer
    {
        public void XmlSerialized(Type dataType,object data, string filePath)
        {
            XmlSerializer  xmlSerializer = new XmlSerializer(dataType);
         
            // If this file exist delete it and create a new one
            if (File.Exists(filePath)) File.Delete(filePath);
            
            // Now create the text writer that will be a new stream writer that has the file path
            TextWriter textWriter = new StreamWriter(filePath);

            // Serialize this file that you created / The data is the data that will be serialized
            xmlSerializer.Serialize(textWriter, data);
            
            // Don't forget to close it
            textWriter.Close();
        }

        public object XmlDeserialize(Type dataType,string filePath)
        {
            object obj = null;
            
            XmlSerializer  xmlSerializer = new XmlSerializer(dataType);

            // Same thing the file exists open it
            // and read it after make the object be a deserialized file, and close the file stream
            if (File.Exists(filePath))
            {
                TextReader textReader = new StreamReader(filePath);
                obj = xmlSerializer.Deserialize(textReader);
                textReader.Close();
            }
            
            return obj;
        }
    }
}