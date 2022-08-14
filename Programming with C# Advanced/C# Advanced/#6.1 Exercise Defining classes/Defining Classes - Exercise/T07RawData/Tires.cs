using System;
using System.Collections.Generic;
using System.Text;

namespace T07RawData
{
    class Tires
    {
        public int Age { get; set; }
        public double Pressure { get; set; }

        public Tires(int age,double pressure)
        {
            Age = age;
            Pressure = pressure;
        }
    }
}
