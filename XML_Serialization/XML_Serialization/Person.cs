using System;

namespace XML_Serialization
{
    // Creating the class that will be serialized
    [Serializable] 
        
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}