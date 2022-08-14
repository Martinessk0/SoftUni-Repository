using System;
using System.Linq;

namespace T08
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int, bool> filter = (allDivisible, number) =>
            {
                bool divisible = true;
                for (int i = 0; i < allDivisible.Length; i++)
                {
                    if (number % allDivisible[i] !=0)
                    {
                        divisible = false;
                        break;
                    }
                }
                return divisible;
            };

            int[] divisibleNumbers = Enumerable.Range(1, range)
                .Where(number => filter(dividers, number))
                .ToArray();
            Console.WriteLine(string.Join(' ',divisibleNumbers));
        }
    }
}
