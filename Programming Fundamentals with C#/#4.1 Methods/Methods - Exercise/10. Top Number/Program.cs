using System;

namespace _10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            PrintTopNumbers(number);
        }

        static void PrintTopNumbers(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                if (DivisionOfSum(i) && OddDigits(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
        static bool DivisionOfSum(int number)
        {
            int sum = 0;
            int currNumber = 0;
            while (number>0)
            {
                currNumber = number % 10;
                sum += currNumber;
                number /= 10;
            }

            if (sum % 8 != 0)
            {
                return false;
            }

            return true;

        }

        static bool OddDigits(int number)
        {
            int currNumber = 0;
            while (number > 0)
            {
                currNumber = number % 10;
                if (currNumber % 2 !=0)
                {
                    return true;
                }
                number /= 10;
            }

            return false;
        }

       
    }
}
