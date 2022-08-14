using System;

namespace T01ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<object> print = msg => Console.WriteLine(msg);
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var name in input)
            {
                print(name);
            }
        }
    }
}
