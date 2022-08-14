using System;

namespace _01._Sign_of_Integer_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            CheckNumber(number);
        }

        static void CheckNumber(int number)
        {
            if (number>0)
            {
                Console.WriteLine($"The number {number} is positive.");
            }

            if (number<0)
            {
                Console.WriteLine($"The number {number} is negative.");
            }

            if (number == 0)
            {
                Console.WriteLine($"The number 0 is zero.");
            }
        }
    }
}
