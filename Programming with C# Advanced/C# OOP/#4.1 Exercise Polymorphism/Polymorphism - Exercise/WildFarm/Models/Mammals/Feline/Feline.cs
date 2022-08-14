namespace WildFarm
{
    public class Feline : Mammal
    {
        public Feline(string name, double weight, int foodEaten, string livingRegion,string breed) : base(name, weight, foodEaten, livingRegion)
        {
            Breed = breed;
        }

        public string Breed { get; set; }
    }
}
