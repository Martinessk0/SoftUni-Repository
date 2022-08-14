using System;
using System.Collections.Generic;

namespace T08
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> regularPeople = new HashSet<string>();
            HashSet<string> vipPeople = new HashSet<string>();
            string input = Console.ReadLine();

            while (input !="PARTY")
            {
                if (isDigit(input[0]))
                {
                    vipPeople.Add(input);
                }
                else
                {
                    regularPeople.Add(input);
                }
                input = Console.ReadLine();
            }

            while (input != "END")
            {
                if (vipPeople.Contains(input))
                {
                    vipPeople.Remove(input);
                }
                else if (regularPeople.Contains(input))
                {
                    regularPeople.Remove(input);
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(regularPeople.Count + vipPeople.Count);

            foreach (var people in vipPeople)
            {
                Console.WriteLine(people);
            }

            foreach (var people in regularPeople)
            {
                Console.WriteLine(people);
            }
        }

        private static bool isDigit(char c)
        {
            for (int i = 0; i <=9; i++)
            {
                if (c.ToString() == i.ToString())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
