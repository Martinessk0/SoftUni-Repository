using System;
using System.Collections.Generic;
using System.Linq;

namespace T01ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToArray();
            Stack<char> reverse = new Stack<char>(input);
            while (reverse.Count > 0)
            {
                Console.Write($"{reverse.Pop()}");
            }
        }
    }
}
