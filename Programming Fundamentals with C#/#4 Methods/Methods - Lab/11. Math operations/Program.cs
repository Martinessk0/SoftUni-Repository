using System;

namespace _11._Math_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            string operations = Console.ReadLine();
            double secondNumber = double.Parse(Console.ReadLine());

            switch (operations)
            {
                case "+":
                    Console.WriteLine(Plus(firstNumber,secondNumber));
                    break;
                case "-":
                    Console.WriteLine(Minus(firstNumber, secondNumber));
                    break;
                case "*":
                    Console.WriteLine(Multiply(firstNumber, secondNumber));
                    break;
                case "/":
                    Console.WriteLine(Division(firstNumber, secondNumber));
                    break;
                case "%":
                    Console.WriteLine(DivisionW(firstNumber, secondNumber));
                    break;
            }
        }

        static double Plus(double a, double b)
        {
            return a + b;
        }

        static double Minus(double a, double b)
        {
            return a - b;
        }

        static double Multiply(double a, double b)
        {
            return a * b;
        }

        static double Division(double a, double b)
        {
            return a / b;
        }
        static double DivisionW(double a, double b)
        {
            return a % b;
        }
    }
}
