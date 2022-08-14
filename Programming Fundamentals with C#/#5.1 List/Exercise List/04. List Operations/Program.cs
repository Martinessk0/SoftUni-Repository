using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split();
            while (command[0] !="End")
            {
                switch (command[0])
                {
                    case "Add":
                        list.Add(int.Parse(command[1]));
                        break;
                    case "Insert":
                        int index = int.Parse(command[2]);
                        int number = int.Parse(command[1]);
                        if (index>=0 && index<list.Count)
                        {
                            list.Insert(index, number);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }
                        
                        break;
                    case "Remove":
                        int currNumb=int.Parse(command[1]);
                        if (currNumb<0 || currNumb>=list.Count)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            list.RemoveAt(int.Parse(command[1]));
                        }
                        break;
                    case "Shift":
                        Shift(list,command[1],int.Parse(command[2]));
                        break;
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", list));
        }

        private static void Shift(List<int> list, string position, int n)
        {
            if (position == "left")
            {
                for (int i = 0; i < n; i++)
                {
                    list.Add(list[0]);
                    list.Remove(list[0]);
                }
            }
            else if (position == "right")
            {
                for (int i = 0; i < n; i++)
                {
                    list.Insert(0,list[list.Count-1]);
                    list.RemoveAt(list.Count-1);
                }
            }
        }
    }
}
