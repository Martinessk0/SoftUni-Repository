using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }
        public decimal Money
        {
            get => money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }
        public IReadOnlyList<Product> Bag => bag;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bag = new List<Product>();
        }
        public void BuyProduct(Product product)
        {
            if (Money >= product.Cost)
            {
                Console.WriteLine($"{Name} bought {product.Name}");
                Money -= product.Cost;
                bag.Add(product);
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
            
        }
    }
}
