using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization
{
    [XmlRoot("Person")]
    public class PersonElements
    {
        [XmlElement("PersonName")]
        public string? Name { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"CLass '{typeof(PersonElements).Name}' with properties Name: '{Name}' and Age: {Age}";
        }
    }
}
