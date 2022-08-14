namespace BirthdayCelebrations
{
    public class Pet : IBirthable
    {
        public Pet(string name,string birthdate)
        {
            Birthdate = birthdate;
            Name = name;
        }
        public string Birthdate { get; set; }
        public string Name { get; set; }
    }
}
