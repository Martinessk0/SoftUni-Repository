using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Dough
    {
        private const string DoughException = "Invalid type of dough.";
        private const string WeightException = "Dough weight should be in the range [1..200].";

        private Dictionary<string, double> flourTypes = new Dictionary<string, double>()
        {
            {"white",1.5},
            {"wholegrain",1}
        };

        private Dictionary<string, double> bakingTechniqueyTypes = new Dictionary<string, double>()
        {
            {"crispy", 0.9},
            {"chewy", 1.1},
            {"homemade", 1}

        };

        private string flourType;
        private string baikingTechniqueType;
        private double weight;

        public string FlourType
        {
            get { return flourType; }
            private set
            {
                if (!flourTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(DoughException);
                }
                flourType = value;
            }
        }
        public string BakingTechniqueType
        {
            get { return baikingTechniqueType; }
            private set
            {
                if (!bakingTechniqueyTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(DoughException);
                }
                baikingTechniqueType = value;
            }
        }
        public double Weight
        {
            get { return weight; }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(WeightException);
                }
                weight = value;
            }
        }
        public double Calories
            => 2 * Weight * flourTypes[flourType.ToLower()] * bakingTechniqueyTypes[baikingTechniqueType.ToLower()];


        public Dough(string flourType,string bakiBaikingTechniqueType,double weight)
        {
            FlourType = flourType;
            BakingTechniqueType = bakiBaikingTechniqueType;
            Weight = weight;
        }
    }
}
