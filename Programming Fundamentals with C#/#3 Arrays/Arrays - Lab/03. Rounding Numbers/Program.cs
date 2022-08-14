using System;
using System.Linq;

namespace _03._Rounding_Numbers
{
    class Program
    {
        static void Main()
        {
            double[] arrayDoubles = Console.ReadLine().Split().Select(double.Parse).ToArray();

            for (int i = 0; i < arrayDoubles.Length; i++)
            {
                if (arrayDoubles[i]==0)
                {
                    arrayDoubles[i] = 0;
                }
                int rounded = (int) Math.Round(arrayDoubles[i], MidpointRounding.AwayFromZero);
                Console.WriteLine($"{arrayDoubles[i]} => {rounded}");
            }
        }
    }
}
