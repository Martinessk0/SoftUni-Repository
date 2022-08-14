using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    class Car : Vehicle
    {
        private const double defaultFuelConsumption = 3;
        public Car(int horsePower, double fuel) : base(horsePower,fuel)
        {
            
        }

        public override double FuelConsumption => defaultFuelConsumption;
    }
}
