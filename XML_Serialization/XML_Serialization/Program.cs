using System;

namespace XML_Serialization
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Creating person object...
            Person person = new Person(){FirstName = "Juliana", LastName =  "Caldeira"};
            
            // Save this in a file called
            string filePath = "data.save";

            // Create a new data serializer
            DataSerializer dataSerializer = new DataSerializer();

            // Make the person object that has information become a data serialized
            dataSerializer.XmlSerialized(typeof(Person),person, filePath);
            
            // Now deserialize it as new var that will be the deserialized object from the class Person
            var personObject = dataSerializer.XmlDeserialize(typeof(Person), filePath) as Person;
            
            // Printing...
            Console.WriteLine(personObject.FirstName);
            Console.WriteLine(personObject.LastName);
        }
    }
}