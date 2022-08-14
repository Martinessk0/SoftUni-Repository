using System;
using System.Linq;

namespace T06
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int divisibleNumber = int.Parse(Console.ReadLine());
            Predicate<int> filter = number => number % divisibleNumber != 0;
            Action<int[]> printer = number => Console.WriteLine(string.Join(' ', number.Reverse().Where(x => filter(x))));
            printer(numbers);
        }
    }
}
