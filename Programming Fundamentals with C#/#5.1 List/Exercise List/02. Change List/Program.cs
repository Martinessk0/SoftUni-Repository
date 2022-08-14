using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    class Program
    {
        static void Main()
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split();

            while (command[0] != "end")
            {
                if (command[0]=="Delete")
                {
                    list.RemoveAll(el => el == int.Parse(command[1]));
                }
                else if (command[0] == "Insert")
                {
                    int number = int.Parse(command[1]);
                    int indexnNumber = int.Parse(command[2]);
                    list.Insert(indexnNumber, number);
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ",list));
        }
    }
}
