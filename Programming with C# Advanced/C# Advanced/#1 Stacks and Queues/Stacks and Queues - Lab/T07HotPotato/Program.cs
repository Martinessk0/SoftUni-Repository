using System;
using System.Collections.Generic;

namespace T07HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            Queue<string> game = new Queue<string>(names);
            int n = int.Parse(Console.ReadLine());
            int currPoss = 1;

            while (game.Count > 1)
            {
                string kidWithPotato = game.Dequeue();
                if (currPoss != n)
                {
                    currPoss++;
                    game.Enqueue(kidWithPotato);
                }
                else
                {
                    currPoss = 1;
                    Console.WriteLine($"Removed {kidWithPotato}");
                }
            }
            Console.WriteLine($"Last is {game.Dequeue()}");
        }
    }
}
