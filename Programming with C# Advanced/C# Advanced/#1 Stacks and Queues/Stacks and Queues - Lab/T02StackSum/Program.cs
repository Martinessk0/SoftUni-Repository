using System;
using System.Collections.Generic;
using System.Linq;

namespace T02StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] number = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[] commands = Console.ReadLine().ToLower().Split();
            Stack<int> numbers = new Stack<int>(number);
            while (commands[0] != "end")
            {
                if (commands[0] == "add")
                {
                    int a = int.Parse(commands[1]);
                    int b = int.Parse(commands[2]);
                    numbers.Push(a);
                    numbers.Push(b);
                }
                else  if (commands[0] == "remove")
                {
                    int a = int.Parse(commands[1]);
                    if (numbers.Count>=a)
                    {
                        for (int i = 0; i < a; i++)
                        {
                            numbers.Pop();
                        }
                    }
                }
                commands = Console.ReadLine().ToLower().Split();
            }
            int sum = 0;
            foreach (var i in numbers)
            {
                sum += i;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
