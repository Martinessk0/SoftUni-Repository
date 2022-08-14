using System;

namespace _08._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            double result1 = Factorial(num1);
            double result2 = Factorial(num2);
            double finalResult = result1 / result2;
            Console.WriteLine($"{finalResult:f2}");
        }

        static double Factorial(int n)
        {
            double factorial = 1;
            for (int i = n; i > 0; i--)
            {
                factorial *= i;
            }

            return factorial;
        }

    }
}
