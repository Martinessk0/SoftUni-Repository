using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T07RawData
{
    class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tires[] Tires { get; set; }

        public Car(string model,Engine engine,Cargo cargo,Tires[] tires)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
            Tires = tires;
        }

        public static Func<Car, bool> GetSpecialCarFragile()
        {
            return x =>
                x.Tires.Any(y => y.Pressure < 1);
        }
        public static Func<Car, bool> GetSpecialCarFlammable()
        {
            return x =>
                x.Engine.HorsePower > 250;
        }

        public string Print()
        {
            return $"{Model}";
        }
    }
}
