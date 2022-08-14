using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.Dtos.Export
{
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("Category")]
    public class CategoryDto
    {
        private string nameField;
        private int countField;
        private decimal averagePriceField;
        private decimal totalRevenueField;

        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
        public int count
        {
            get
            {
                return this.countField;
            }
            set
            {
                this.countField = value;
            }
        }
        public decimal averagePrice
        {
            get
            {
                return this.averagePriceField;
            }
            set
            {
                this.averagePriceField = value;
            }
        }
        public decimal totalRevenue
        {
            get
            {
                return this.totalRevenueField;
            }
            set
            {
                this.totalRevenueField = value;
            }
        }
    }
}
