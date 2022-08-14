using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("User")]
    public class UserSoldProductDto
    {

        private string firstNameField;
        private string lastNameField;
        private SoldProductDto[] soldProductsField;

        public string firstName
        {
            get
            {
                return this.firstNameField;
            }
            set
            {
                this.firstNameField = value;
            }
        }
        public string lastName
        {
            get
            {
                return this.lastNameField;
            }
            set
            {
                this.lastNameField = value;
            }
        }
        [System.Xml.Serialization.XmlArrayItemAttribute("Product", IsNullable = false)]
        public SoldProductDto[] soldProducts
        {
            get
            {
                return this.soldProductsField;
            }
            set
            {
                this.soldProductsField = value;
            }
        }

    }
}
