using System;
using System.Collections.Generic;
using System.Linq;

namespace T03SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();
            Stack<string> calculator = new Stack<string>(input);
            while (calculator.Count > 1)
            {
                int num1 = int.Parse(calculator.Pop());
                string symbol = calculator.Pop();
                int num2 = int.Parse(calculator.Pop());

                if (symbol == "+")
                {
                    calculator.Push((num1+num2).ToString());
                }
                else if (symbol == "-")
                {
                    calculator.Push((num1 - num2).ToString());
                }
            }
            Console.WriteLine(calculator.Pop());
        }
    }
}
