using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] input = Console.ReadLine().Split().ToArray();
            while (input[0] != "end")
            {
                if (input[0]== "Add")
                {
                     list.Add(int.Parse(input[1]));
                }
                else if (input[0]=="Remove")
                {
                    list.Remove(int.Parse(input[1]));
                }
                else if (input[0] == "RemoveAt")
                {
                    list.RemoveAt(int.Parse(input[1]));
                }
                else if (input[0] == "Insert")
                {
                    int insertNumber = int.Parse(input[1]);
                    int insertIndex = int.Parse(input[2]);
                    list.Insert(insertIndex, insertNumber);
                }
                input = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ",list));
        }
    }
}
