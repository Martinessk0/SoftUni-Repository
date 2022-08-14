using System;
using System.Collections.Generic;
using System.Linq;

namespace T05FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int capacity = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>(clothes);
            int numbersOfRacks = 1;
            int sum = 0;

            while (stack.Count>0)
            {
                sum += stack.Peek();
                if (sum <= capacity)
                {
                    stack.Pop();
                }
                else
                {
                    numbersOfRacks++;
                    sum = 0;
                }
            }
            Console.WriteLine(numbersOfRacks);
        }
    }
}
`