using System;

namespace _06._Strong_number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int thirdNumber = number % 10;//3
            int secondNumber = number / 10; secondNumber %= 10;//2
            int firstNumber = number / 100; firstNumber %= 10;//1

            int max1 = 1;
            int max2 = 1;
            int max3 = 1;
            if (firstNumber==0)
            {
                max1 = 0;
            }
            if (secondNumber==0)
            {
                max2 = 0;
            }
            for (int i = firstNumber; i > 0; i--)
            {
                max1 *= i;
            }
            for (int i = secondNumber; i > 0; i--)
            {
                max2 *= i;
            }
            for (int i = thirdNumber; i > 0; i--)
            {
                max3 *= i;
            }

            if ((max1+max2+max3)== number)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
