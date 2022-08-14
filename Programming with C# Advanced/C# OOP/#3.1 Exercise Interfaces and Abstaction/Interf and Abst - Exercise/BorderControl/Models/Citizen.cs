using System;
using System.Collections.Generic;
using System.Text;
using BorderControl.Contracts;

namespace BorderControl
{
    public class Citizen : IIdentifable
    {
        public Citizen(string id,string name,int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }
        public string Id { get; set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
    }
}
