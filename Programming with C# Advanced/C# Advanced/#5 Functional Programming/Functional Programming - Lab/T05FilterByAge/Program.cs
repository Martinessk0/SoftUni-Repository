using System;
using System.Collections.Generic;
using System.Linq;

namespace T05FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<(string name, int age), int, bool> younger = (person, a) => person.age < a;
            Func<(string name, int age), int, bool> older = (person, a) => person.age >= a;

            int n = int.Parse(Console.ReadLine());
            List<(string name, int age)> people = new List<(string name, int age)>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                people.Add((input[0],int.Parse(input[1])));
            }

            string cond = Console.ReadLine();
            int filter = int.Parse(Console.ReadLine());

            string[] printFormat = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            switch (cond)
            {
                case "younger":
                    people = people
                        .Where(p => younger(p, filter))
                        .ToList();
                    break;
                case "older":
                    people = people
                        .Where(p => older(p, filter))
                        .ToList();
                    break;
            }

            foreach (var person in people)
            {
                List<string> output = new List<string>();
                if (printFormat.Contains("name"))
                {
                    output.Add(person.name);
                }

                if (printFormat.Contains("age"))
                {
                    output.Add(person.age.ToString());
                }

                Console.WriteLine(string.Join(" - ",output));
            }
        }
    }
}
