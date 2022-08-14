using System;
using System.Collections.Generic;
using System.Text;
using BorderControl.Contracts;

namespace BorderControl
{
    public class Robot : IIdentifable
    {
        public Robot(string id,string model)
        {
            Id = id;
            Model = model;
        }
        public string Id { get; set; }
        public string Model { get; set; }
    }
}
