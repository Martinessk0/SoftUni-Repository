using System;
using System.Collections.Generic;
using System.Linq;

namespace T01BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] operations = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int stackCount = operations[0];
            int popOutElemnts = operations[1];
            int seek = operations[2];
            int min = int.MaxValue;
            bool isFound = false;
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(numbers);

            for (int i = 0; i < popOutElemnts; i++)
            {
                stack.Pop();
            }
            if (stack.Contains(seek))
            {
                Console.WriteLine("true");
                isFound = true;
            }
            else if(stack.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                foreach (var i in stack)
                {
                    if (min>=i)
                    {
                        min = i;
                    }
                }
                Console.WriteLine(min);
            }
        }
    }
}
