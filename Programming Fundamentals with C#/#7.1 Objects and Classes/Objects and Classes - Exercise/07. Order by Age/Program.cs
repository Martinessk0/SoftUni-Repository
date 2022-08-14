using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Order_by_Age
{
    class Program
    {
        class ID
        {
            public string Name { get; set; }
            public string IDnumber { get; set; }
            public int Age { get; set; }

            public override string ToString()
            {
                return base.ToString();
            }
        }
        static void Main(string[] args)
        {
            string[] cmd = Console.ReadLine().Split();
            List<ID> peoples = new List<ID>();
            while (cmd[0] != "End")
            {
                string name = cmd[0];
                string serialNumber = cmd[1];
                int age = int.Parse(cmd[2]);
                ID idNumber = new ID()
                {
                    Age = age,
                    IDnumber = serialNumber,
                    Name = name
                };
                peoples.Add(idNumber);
                foreach (var people in peoples)
                {
                    if (people.IDnumber.Contains(serialNumber))
                    {
                        people.Name = name;
                        people.Age = age;
                    }
                }
                cmd = Console.ReadLine().Split();
            }

            foreach (var people in peoples.OrderBy(x => x.Age))
            {
                Console.WriteLine($"{people.Name} with ID: {people.IDnumber} is {people.Age} years old.");
            }
            
        }
    }
}
