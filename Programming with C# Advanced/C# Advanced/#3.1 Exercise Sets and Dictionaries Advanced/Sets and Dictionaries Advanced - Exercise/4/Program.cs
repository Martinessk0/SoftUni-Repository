using System;
using System.Collections.Generic;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> evenCount = new Dictionary<int, int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                if (evenCount.ContainsKey(input) == false)
                {
                    evenCount.Add(input, 1);
                }
                else if (evenCount.ContainsKey(input))
                {
                    evenCount[input]++;
                }
            }

            foreach (var numbers in evenCount)
            {
                if (numbers.Value % 2 == 0)
                {
                    Console.WriteLine($"{numbers.Key}");
                }
            }
        }
    }
}
