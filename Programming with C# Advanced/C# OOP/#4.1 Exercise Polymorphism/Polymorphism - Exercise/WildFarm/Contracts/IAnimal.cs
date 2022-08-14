using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public interface IAnimal
    {
        string Name { get; set; }
        double Weight { get; set; }
        int FoodEaten { get; set; }
        public abstract string ProduceSound();
        public abstract void Eat(IFood food);
    }
}
