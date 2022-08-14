using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
    //<CategoryProduct>
    //    <CategoryId>4</CategoryId>
    //    <ProductId>1</ProductId>
    //</CategoryProduct>
    [XmlType("CategoryProduct")]
    public class CategoryProductImportDto
    {
        [XmlElement("CategoryId")]
        public int CategoryId { get; set; }
        [XmlElement("ProductId")]
        public int ProductId { get; set; }
    }
}
