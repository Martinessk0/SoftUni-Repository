using System;

namespace _01._Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            Console.WriteLine(GetMin(num1,num2,num3));
        }

        static int GetMin(int a, int b, int c)
        {
            int result = Math.Min(a, Math.Min(b, c));
            return result;
        }
    }
}
