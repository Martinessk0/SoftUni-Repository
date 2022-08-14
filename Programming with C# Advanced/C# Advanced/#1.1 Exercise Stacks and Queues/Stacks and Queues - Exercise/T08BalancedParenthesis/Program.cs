using System;
using System.Collections.Generic;
using System.Linq;

namespace T08BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            Stack<char> stack = new Stack<char>();
            foreach (var symbol in input)
            {
                if (stack.Any())
                {
                    char check = stack.Peek();
                    if (check == '{' && symbol == '}')
                    {
                        stack.Pop();
                        continue;
                    }
                    else if (check == '[' && symbol == ']')
                    {
                        stack.Pop();
                        continue;
                    }
                    else if (check == '(' && symbol == ')')
                    {
                        stack.Pop();
                        continue;
                    }
                }
                stack.Push(symbol);
            }
            Console.WriteLine(!stack.Any() ? "YES" : "NO");
        }
    }
}
