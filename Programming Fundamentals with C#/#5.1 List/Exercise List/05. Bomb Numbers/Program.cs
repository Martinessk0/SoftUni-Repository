using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] bombOperation = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int itemToKill = bombOperation[0];
            int rangeToKill = bombOperation[1];
            int index = 0;

            while (list.Contains(itemToKill))
            {
                index = list.IndexOf(itemToKill);
                int leftRange = rangeToKill;
                int rightRange = rangeToKill;

                if (index - leftRange < 0) leftRange = index;
                if (index + rightRange >= list.Count) rightRange = list.Count - index - 1;

                list.RemoveRange(index - leftRange, leftRange + rightRange + 1);
            }

            Console.WriteLine(list.Sum());

        }
    }
}
