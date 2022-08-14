using System;

namespace _04._Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split();
            string[] reverseArray = new string[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                reverseArray[i] = array[array.Length - i - 1];
                Console.Write($"{reverseArray[i]} ");
            }
        }
    }
}
