namespace WildFarm
{
    public abstract class Animal :IAnimal
    {
        public Animal(string name,double weight,int foodEaten)
        {
            Name = name;
            Weight = weight;
            FoodEaten = foodEaten;
        }

        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }
    }
}
