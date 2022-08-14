using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Channels;

namespace _07._List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] input = Console.ReadLine().Split();
            bool change = false;
            while (input[0] != "end")
            {
                if (input[0] == "Add")
                {
                    list.Add(int.Parse(input[1]));
                    change = true;
                }
                else if (input[0] == "Remove")
                {
                    list.Remove(int.Parse(input[1]));
                    change = true;
                }
                else if (input[0] == "RemoveAt")
                {
                    list.RemoveAt(int.Parse(input[1]));
                    change = true;
                }
                else if (input[0] == "Insert")
                {
                    int insertNumber = int.Parse(input[1]);
                    int insertIndex = int.Parse(input[2]);
                    list.Insert(insertIndex, insertNumber);
                    change = true;
                }
                else if (input[0] == "Contains")
                {
                    if (list.Contains(int.Parse(input[1]))) Console.WriteLine("Yes");
                    else Console.WriteLine("No such number");
                }
                else if (input[0] == "PrintEven")
                {
                    PrintEven(list);
                }
                else if (input[0] == "PrintOdd")
                {
                    PrintOdd(list);
                }
                else if (input[0] == "GetSum")
                {
                    Console.WriteLine(GetSum(list));
                }
                else if (input[0] == "Filter")
                {
                    string condition = input[1];
                    int number = int.Parse(input[2]);
                    Filter(condition, number, list);
                }
                input = Console.ReadLine().Split();
            }

            if (change) Console.WriteLine(string.Join(" ", list));


        }

        static void Filter(string condition, int number, List<int> list)
        {
            List<int> filterList = new List<int>();
            switch (condition)
            {
                case "<":
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] < number) filterList.Add(list[i]);
                    }
                    break;
                case ">":
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] > number) filterList.Add(list[i]);
                    }
                    break;
                case ">=":
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] >= number) filterList.Add(list[i]);
                    }
                    break;
                case "<=":
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] <= number) filterList.Add(list[i]);
                    }
                    break;
            }
            Console.WriteLine(string.Join(" ", filterList));
        }
        static int GetSum(List<int> list)
        {
            int sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                sum += list[i];
            }

            return sum;
        }
        static void PrintOdd(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 == 1)
                {
                    Console.Write($"{list[i]} ");
                }
            }
            Console.WriteLine();
        }
        static void PrintEven(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 == 0)
                {
                    Console.Write($"{list[i]} ");
                }
            }

            Console.WriteLine();
        }
    }
}
