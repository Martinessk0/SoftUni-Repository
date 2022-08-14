using System;

namespace _07._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            const int CAPACITY = 255;

            int n = int.Parse(Console.ReadLine());
            int totalQuantity = 0;

            for (int i = 1; i <= n; i++)
            {
                int liters = int.Parse(Console.ReadLine());

                if ((totalQuantity+liters)>CAPACITY)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    totalQuantity += liters;
                }
                
            }
            Console.WriteLine(totalQuantity);
        }
    }
}
