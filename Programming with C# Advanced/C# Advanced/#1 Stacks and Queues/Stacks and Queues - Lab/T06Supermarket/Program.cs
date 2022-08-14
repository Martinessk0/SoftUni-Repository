using System;
using System.Collections.Generic;

namespace T06Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Queue<string> names = new Queue<string>();
            while (input[0] != "End")
            {
                if (input[0] == "Paid")
                {
                    int count = names.Count;
                    for (int i = 0; i < count; i++)
                    {
                        Console.WriteLine(names.Dequeue());
                    }
                }
                else
                {
                    names.Enqueue(input[0]);
                }
                input = Console.ReadLine().Split();
            }
            Console.WriteLine($"{names.Count} people remaining.");
        }
    }
}
