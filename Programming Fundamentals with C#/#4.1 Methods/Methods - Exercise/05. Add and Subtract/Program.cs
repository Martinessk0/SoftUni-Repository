using System;

namespace _05._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int sumOfFirstTwoNumbers = SumFirstNumber(num1, num2);
            int subtractOfSecondTwoNumbers = SubtractSecondNumbers(sumOfFirstTwoNumbers, num3);

            Console.WriteLine(subtractOfSecondTwoNumbers);
        }

        static int SumFirstNumber(int a, int b)
        {
            return a + b;
        }

        static int SubtractSecondNumbers(int a, int b)
        {
            return a - b;
        }
    }
}
