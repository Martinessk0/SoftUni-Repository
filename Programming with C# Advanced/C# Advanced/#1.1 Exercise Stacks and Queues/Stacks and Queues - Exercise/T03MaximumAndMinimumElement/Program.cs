using System;
using System.Collections.Generic;

namespace T03MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();
                int min = int.MaxValue;
                int max = int.MinValue;

                switch (int.Parse(command[0]))
                {
                    case 1:
                        int x = int.Parse(command[1]);
                        stack.Push(x);
                        break;
                    case 2:
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }
                        break;
                    case 3:
                        if (stack.Count > 0)
                        {
                            foreach (var i1 in stack)
                            {
                                if (max <= i1)
                                {
                                    max = i1;
                                }
                            }
                            Console.WriteLine(max);
                        }
                        break;
                    case 4:
                        if (stack.Count > 0)
                        {
                            foreach (var i1 in stack)
                            {
                                if (min >= i1)
                                {
                                    min = i1;
                                }
                            }
                            Console.WriteLine(min);
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
