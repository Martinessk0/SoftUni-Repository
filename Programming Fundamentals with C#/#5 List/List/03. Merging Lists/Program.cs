using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> list2 = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> mergingList = new List<int>();
            int biggerList = Math.Max(list1.Count, list2.Count);
            for (int i = 0; i < biggerList; i++)
            {
                if (i<list1.Count)
                {
                    mergingList.Add(list1[i]);
                }

                if (i<list2.Count)
                {
                    mergingList.Add(list2[i]);
                }
            }

            Console.WriteLine(string.Join(" ",mergingList));
        }
    }
}
