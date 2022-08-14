using System;
using System.Collections.Generic;
using System.Linq;

namespace T04FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(orders);
            FindTheBiggestOrder(queue);

            while (queue.Count != 0)
            {
                int currOrder = queue.Peek();
                if (quantityOfFood >=currOrder)
                {
                    quantityOfFood -= currOrder;
                    queue.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(' ',queue)}");
                    return;
                }
            }
            Console.WriteLine("Orders complete");
        }

        private static void FindTheBiggestOrder(Queue<int> queue)
        {
            int max = int.MinValue;
            foreach (var i in queue)
            {
                if (max <= i)
                {
                    max = i;
                }
            }
            Console.WriteLine(max);
        }
    }
}
