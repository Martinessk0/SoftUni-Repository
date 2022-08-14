using System;
using System.Collections.Generic;
using System.Text;

namespace T08CarSalesman
{
    class Engine
    {
        public Engine(string model,int power)
        {
            Model = model;
            Power = power;
        }
        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"  {Model}:");
            sb.AppendLine();
            sb.AppendLine($"    Power: {Power}");  
            sb.AppendLine(Displacement == 0 ? "    Displacement: n/a" : $"    Displacement: {Displacement}");

            sb.Append(Efficiency == null ? "    Efficiency: n/a" : $"    Efficiency: {Efficiency}");

            return sb.ToString();
        }
    }
}
