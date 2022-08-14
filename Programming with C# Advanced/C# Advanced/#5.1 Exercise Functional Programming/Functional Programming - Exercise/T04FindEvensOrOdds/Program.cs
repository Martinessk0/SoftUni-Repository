using System;
using System.Collections.Generic;
using System.Linq;

namespace T04FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bounds = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string type = Console.ReadLine();

            Predicate<int> predicate = type == "odd"
                ? number => number % 2 != 0 
                : new Predicate<int>(number => number % 2 == 0);

            List<int> result = new List<int>();

            for (int i = bounds[0]; i <= bounds[1]; i++)
            {
                if (predicate(i))       
                {
                    result.Add(i);
                }
            }

            foreach (var number in result)
            {
                Console.Write($"{number} ");
            }
        }
    }
}
