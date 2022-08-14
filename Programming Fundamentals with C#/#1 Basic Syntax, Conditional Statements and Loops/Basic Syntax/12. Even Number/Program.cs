using System;

namespace _12._Even_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            while (true)
            {
                if (n % 2 != 0)
                {
                    Console.WriteLine("Please write an even number.");
                }
                else if(n % 2 == 0)
                {
                    Console.WriteLine($"The number is: {Math.Abs(n)}");
                    break;
                }
                n = int.Parse(Console.ReadLine());
            }
        }
    }
}
