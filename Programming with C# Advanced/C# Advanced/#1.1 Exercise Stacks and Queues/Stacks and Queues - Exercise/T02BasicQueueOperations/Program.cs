using System;
using System.Collections.Generic;
using System.Linq;

namespace T02BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] operation = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int remove = operation[1];
            int seek = operation[2];
            int min = int.MaxValue;
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(numbers);

            for (int i = 0; i < remove; i++)
            {
                queue.Dequeue();
            }
            if (queue.Contains(seek))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                foreach (var i in queue)
                {
                    if (min >= i)
                    {
                        min = i;
                    }
                }
                Console.WriteLine(min);
            }
        }
    }
}
