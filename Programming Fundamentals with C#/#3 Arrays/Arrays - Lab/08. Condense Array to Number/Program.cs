using System;
using System.Linq;

namespace _08._Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] originalArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int finalResult = 0;
            int firstLenght = originalArray.Length - 1;
            if (originalArray[0] == 1)
            {
                finalResult++;
                Console.WriteLine(finalResult);
                return;
            }
            for (int i = 0; i < firstLenght; i++)
            {
                int[] modifiedArray = new int[originalArray.Length-1];
                for (int j = 0; j < modifiedArray.Length; j++)
                modifiedArray[j] += originalArray[j] + originalArray[j + 1]; 
                originalArray = modifiedArray;
                finalResult = modifiedArray[0];
            }
            Console.WriteLine(finalResult);

        }
    }
}
