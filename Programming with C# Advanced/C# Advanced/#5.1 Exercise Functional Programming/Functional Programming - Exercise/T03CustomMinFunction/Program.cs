using System;
using System.Linq;

namespace T03CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> minNum = n => n.Min();
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)              
                .ToArray();
            Console.WriteLine(minNum(input));

        }
    }
}
