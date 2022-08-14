using System;
using System.Linq;

namespace T03
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            foreach (var number in numbers.OrderByDescending(x => x).Take(3))
            {
                Console.Write($"{number} ");
            }
        }
    }
}
