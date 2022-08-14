using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
    //<User>
    //    <firstName>Chrissy</firstName>
    //    <lastName>Falconbridge</lastName>
    //    <age>50</age>
    //</User>
    [XmlType("User")]
    public class UserImportDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }
        [XmlElement("lastName")]
        public string LastName { get; set; }
        [XmlElement("age")]
        public string Age { get; set; }
    }
}
