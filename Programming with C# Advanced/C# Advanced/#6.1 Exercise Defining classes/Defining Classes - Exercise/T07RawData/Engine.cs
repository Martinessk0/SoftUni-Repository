using System;
using System.Collections.Generic;
using System.Text;

namespace T07RawData
{
    class Engine
    {
        public int Speed { get; set; }
        public int HorsePower { get; set; }

        public Engine(int speed,int horsePower)
        {
            Speed = speed;
            HorsePower = horsePower;
        }
    }
}
