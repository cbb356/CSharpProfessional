using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Deserialization
{
    [XmlType("Person")]
    public class PersonAttributes
    {
        [XmlAttribute]
        public string? Name { get; set; }
        [XmlAttribute]
        public int Age { get; set; }

        public override string ToString()
        {
            return $"CLass '{typeof(PersonAttributes).Name}' with properties Name: '{Name}' and Age: {Age}";
        }
    }
}
