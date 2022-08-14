using System;
using System.Linq;

namespace T05
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Action<object> printer = number => Console.WriteLine(string.Join(" ", numbers));
            string token = Console.ReadLine();
            while (token != "end") 
            {
                switch (token)
                {
                    case "add":
                        numbers = ForEach(numbers, x => ++x);
                        break;
                    case "multiply":
                        numbers = ForEach(numbers, y => y * 2);
                        break;
                    case "subtract":
                        numbers = ForEach(numbers, z => --z);
                        break;
                    case "print":
                        printer(numbers);
                        break;
                }
                token = Console.ReadLine();
            }
        }
        public static int[] ForEach(int[] numbers, Func<int, int> func) =>
            numbers.Select(number => func(number)).ToArray();
    }
}
