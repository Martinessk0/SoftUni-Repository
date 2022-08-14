using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[] command = Console.ReadLine().Split();

            while (command[0] != "end")
            {
                if (command[0] == "exchange")
                {
                    array = ExchangeArr(array, int.Parse(command[1]));
                }
                else if (command[0] == "max" || command[0] == "min")
                {
                    FindMinMax(array, command[0], command[1]);
                }
                else
                {
                    FindNumbers(array, command[0], int.Parse(command[1]), command[2]);
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine($"[{string.Join(", ", array)}]");
        }

        static int[] ExchangeArr(int[] currentArray, int splitIndex)
        {
            if (splitIndex >= currentArray.Length || splitIndex < 0)
            {
                Console.WriteLine("Invalid index");
                return currentArray;
            }
            for (int i = 0; i < splitIndex+1; i++)
            {
                int temp = currentArray[0];
                for (int j = 0; j < currentArray.Length - 1; j++)
                {
                    currentArray[j] = currentArray[j + 1];
                }
                currentArray[currentArray.Length - 1] = temp;
            }
            return currentArray;
        }

        static void FindMinMax(int[] currArray, string minOrMax, string evenOrOdd)
        {
            int index = -1;
            int min = int.MaxValue;
            int max = int.MinValue;
            int resultOddEven = 1;
            if (evenOrOdd == "even") resultOddEven = 0;
            for (int i = 0; i < currArray.Length; i++)
            {
                if (currArray[i] % 2 ==resultOddEven)
                {
                    if (minOrMax == "max" && max <=currArray[i])
                    {
                        max = currArray[i];
                        index = i;
                    }
                    else if (minOrMax == "min" && min >=currArray[i])
                    {
                        min = currArray[i];
                        index = i;
                    }
                }
            }
            if (index> -1)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        static void FindNumbers(int[] currArray, string position,int numbersCount, string evenOrOdd)
        {
            if (numbersCount > currArray.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            if (numbersCount == 0)
            {
                Console.WriteLine("[]");
                return;
            }

            int resultOddEven = 1;
            if (evenOrOdd == "even") resultOddEven = 0;

            int count = 0;
            List<int> nums = new List<int>();
            if (position=="first")
            {
                foreach (var num in currArray)
                {
                    if (num % 2 == resultOddEven)
                    {
                        count++;
                        nums.Add(num);
                    }
                    if (count==numbersCount) break;
                }
            }
            else
            {
                for (int currIndex = currArray.Length-1; currIndex >= 0; currIndex--)
                {
                    if (currArray[currIndex] % 2 == resultOddEven)
                    {
                        count++;
                        nums.Add(currArray[currIndex]);
                    }
                    if (count==numbersCount) break;
                }
                nums.Reverse();
            }

            Console.WriteLine($"[{string.Join(", ", nums)}]");
        }
    }
}
