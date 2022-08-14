using System;

namespace _06._Calculate_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double sideA = double.Parse(Console.ReadLine());
            double sideB = double.Parse(Console.ReadLine());
            Console.WriteLine(Rectangle(sideA, sideB));
        }

        static double Rectangle(double sideA, double sideB)
        {
            return sideA * sideB;
        }
    }
}
