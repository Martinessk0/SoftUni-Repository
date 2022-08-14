using System;

namespace T02KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<object> printSir = name => Console.WriteLine($"Sir {name}");
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var name in input)
            {
                printSir(name);
            }
        }
    }
}
