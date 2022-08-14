using System;

namespace _02._Print_Numbers_in_Reverse_Order
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            int[] ReverseArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] =int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < array.Length; i++)
            {
                ReverseArray[i] = array[(array.Length - i - 1)];
                Console.Write($"{ReverseArray[i]} ");
            }
          
        }
    }
}
