using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        public string Model { get; set; }
        public string Color { get; set; }

        public Seat(string model,string color)
        {
            Model = model;
            Color = color;
        }
        public string Start()
            => "Engine start";
        public string Stop()
            => "Breaaak!";

        public override string ToString()
            => $"{Color} Tesla {Model}";
    }
}
