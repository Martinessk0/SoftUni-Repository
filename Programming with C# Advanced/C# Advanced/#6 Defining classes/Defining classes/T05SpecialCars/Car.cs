using System;
using System.Linq;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }
        public Car(string make, string model, int year)
            : this()
        {
            Make = make;
            Model = model;
            Year = year;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
        : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            Engine = engine;
            Tires = tires;
        }

        public string Make { get => make; set => make = value; }
        public string Model { get => model; set => model = value; }
        public int Year { get => year; set => year = value; }
        public double FuelQuantity { get => fuelQuantity; set => fuelQuantity = value; }
        public double FuelConsumption { get => fuelConsumption; set => fuelConsumption = value; }
        public Engine Engine { get => engine; set => engine = value; }
        public Tire[] Tires { get => tires; set => tires = value; }

        public void Drive(double distance)
        {
            if (FuelQuantity - (FuelConsumption * distance / 100) >= 0)
                FuelQuantity -= distance * FuelConsumption / 100;
        }
        public static Func<Car, bool> GetSpecialCars()
        {
            return x =>
                x.Year >= 2017
                && x.Engine.HorsePower > 330
                && x.Tires.Sum(y => y.Pressure) >= 9.0
                && x.Tires.Sum(y => y.Pressure) <= 10.0;
        }

        public string Print()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Make: {Make}");
            result.AppendLine($"Model: {Model}");
            result.AppendLine($"Year: {Year}");
            result.AppendLine($"HorsePowers: {Engine.HorsePower}");
            result.AppendLine($"FuelQuantity: {FuelQuantity}");
            return result.ToString();
        }
    }
}