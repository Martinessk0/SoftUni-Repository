using System;
using System.Linq;

namespace _06._Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            for (int i = 0; i < array.Length; i++)
            {
                if (array.Length == 1)
                {
                    Console.WriteLine(0);
                    return;
                }
                //leftSum
                int leftSum = 0;
                for (int j = i; j > 0; j--)
                {
                    int nextElement = j - 1;
                    if (j>0)
                    {
                        leftSum += array[nextElement];
                    }
                }
                //rightSum
                int rightSum = 0;
                for (int j = i; j < array.Length; j++)
                {
                    int nextElement = j + 1;
                    if (j<array.Length-1)
                    {
                        rightSum += array[nextElement];
                    }
                }

                if (leftSum==rightSum)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
            Console.WriteLine("no");
        }
    }
}
