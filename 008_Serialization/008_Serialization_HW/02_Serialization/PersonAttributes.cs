using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization
{
    [XmlType("Person")]
    public class PersonAttributes
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public int Age { get; set; }
    }
}
