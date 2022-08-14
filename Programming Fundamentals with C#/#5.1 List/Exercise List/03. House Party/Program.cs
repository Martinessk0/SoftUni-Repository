using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> guestList = new List<string>();
            string[] command;
            for (int i = 0; i < n; i++)
            {
                command = Console.ReadLine().Split();
                //guestList.Add(command[0]);
                if (command[2] == "going!")//going
                {
                    if (guestList.Contains(command[0]))
                    {
                        Console.WriteLine($"{command[0]} is already in the list!");
                    }
                    else
                    {
                        guestList.Add(command[0]);
                    }
                }
                else if (command[2] == "not")//not going
                {
                    if (guestList.Contains(command[0]))
                    {
                        guestList.Remove(command[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{command[0]} is not in the list!");
                    }
                }
            }

            for (int i = 0; i < guestList.Count; i++)
            {
                Console.WriteLine(guestList[i]);
            }

        }
    }
}
