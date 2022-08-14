using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main()
        {
            List<int> wagonList = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxCapacity = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split();
            while (input[0] != "end")
            {
                if (input[0]=="Add")
                {
                    wagonList.Add(int.Parse(input[1]));
                }
                else
                {
                    for (int i = 0; i < wagonList.Count; i++)
                    {
                        if (wagonList[i]+ int.Parse(input[0]) <= maxCapacity)
                        {
                            wagonList[i] += int.Parse(input[0]);
                            break;
                        }
                    }
                }
                input = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ",wagonList));
        }
    }
}
