using System;
using System.Linq;

namespace T04AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
             decimal[] numbers=Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .Select(p => p * 1.2M)
                .ToArray();
             foreach (var number in numbers)      
             {
                 Console.WriteLine($"{number:f2}");
             }
        }
    }
}
