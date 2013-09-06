using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace WSAPIReader.Models
{
    public class ReferenceTypes
    {
        [XmlElement("ReferenceType")]
        public List<ReferenceType> refs;

        public ReferenceTypes()
        {
            refs = new List<ReferenceType>();
        }
    }

    public class ReferenceType
    {
        //[XmlElement("Id")]
        //public int Id { get; set; }
        [XmlElement("Code")]
        public string Code { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; }
    }

    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
    }
}
