using System;
using System.Collections.Generic;

namespace T06SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ");
            string commands = Console.ReadLine();
            Queue<string> queue = new Queue<string>(songs);

            while (queue.Count > 0)
            {
                if (commands.Substring(0, 4) == "Play")
                {
                    queue.Dequeue();
                }
                else if(commands.Substring(0, 3) == "Add")
                {
                    commands=commands.Remove(0, 4);
                    if (!queue.Contains(commands)) queue.Enqueue(commands);
                    else Console.WriteLine($"{commands} is already contained!");
                }
                else if (commands.Substring(0, 4) == "Show")
                {
                    Console.WriteLine(string.Join(", ", queue));
                }
                commands = Console.ReadLine();
            }
            Console.WriteLine("No more songs!");
        }
    }
}
