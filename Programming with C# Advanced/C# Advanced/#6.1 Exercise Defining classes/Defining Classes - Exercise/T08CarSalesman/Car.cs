using System;
using System.Collections.Generic;
using System.Text;

namespace T08CarSalesman
{
    class Car
    {
        public Car(string model,Engine engine)
        {
            Model = model;
            Engine = engine;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Model}:");
            sb.AppendLine($"{Engine}");
            sb.AppendLine(Weight == 0 ? "  Weight: n/a" : $"  Weight: {Weight}");
            sb.Append(Color == null ? "  Color: n/a" : $"  Color: {Color}");


            return sb.ToString();
        }
    }
}
