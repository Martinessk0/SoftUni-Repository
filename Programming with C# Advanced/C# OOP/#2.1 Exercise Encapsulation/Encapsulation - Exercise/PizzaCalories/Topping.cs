using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PizzaCalories
{
    public class Topping
    {
        private Dictionary<string, double> toppingsTypes = new Dictionary<string, double>()
        {
            {"meat",1.2},
            {"veggies",0.8},
            {"cheese",1.1},
            {"sauce",0.9}
        };

        private string type;
        private double weight;

        public string Type
        {
            get=>type;
            private set
            {
                if (!toppingsTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                type = value;
            }
        }

        public double Weight
        {
            get=> weight;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }

        public double Calories
            => 2 * Weight * toppingsTypes[Type.ToLower()];

        public Topping(string type,double weight)
        {
            Type = type;
            Weight = weight;
        }
    }
}
