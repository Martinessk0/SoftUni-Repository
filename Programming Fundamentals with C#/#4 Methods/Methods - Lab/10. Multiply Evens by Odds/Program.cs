using System;

namespace _10._Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));
            int evenSum=GetSumOfEvenDigits(number);
            int oddSum=GetSumOfOddDigits(number);

            Console.WriteLine(GetMultipleOfEvenAndOdds(evenSum,oddSum));
        }

        static int GetSumOfEvenDigits(int num)
        {
            int evenSum = 0;
            int currNumber = 0;
            while (num>0)
            {
                currNumber = num % 10;
                num /= 10;
                if (currNumber%2==0)
                {
                    evenSum += currNumber;
                }
            }
            return evenSum;
        }

        static int GetSumOfOddDigits(int num)
        {
            int oddSum = 0;
            int currNumber = 0;
            while (num > 0)
            {
                currNumber = num % 10;
                num /= 10;
                if (currNumber % 2 != 0)
                {
                    oddSum += currNumber;
                }
            }
            return oddSum;
        }

        static int GetMultipleOfEvenAndOdds(int evenSum, int oddSum)
        {
            return evenSum * oddSum;
        }
    }
}
