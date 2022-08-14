namespace FoodShortage
{
    public class Citizen : IBirthable ,IIdentifable,IBuyer
    {
        public Citizen(string id,string name,int age,string birthdate)
        {
            Id = id;
            Name = name;
            Age = age;
            Birthdate = birthdate;
        }
        public string Id { get; set; }
        public string Name { get; private set; }
        public int Food { get; private set; }
        public int Age { get; private set; }
        public string Birthdate { get; set; }
        public void BuyFood()
        {
            Food += 10;
        }

        
    }
}
