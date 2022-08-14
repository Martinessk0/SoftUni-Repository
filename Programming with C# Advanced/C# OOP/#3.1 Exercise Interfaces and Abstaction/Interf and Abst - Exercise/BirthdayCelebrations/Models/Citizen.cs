namespace BirthdayCelebrations
{
    public class Citizen : IBirthable ,IIdentifable
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
        public int Age { get; private set; }
        public string Birthdate { get; set; }
    }
}
