using System;

namespace _05._Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());


            for (int i = 1; i <= number; i++)
            {
                int n = i;
                int sum = 0;
                while (n > 0)
                {
                    sum += n % 10;
                    n /= 10;
                }

                bool isStrong = false;

                if (sum % 7 == 0 || sum % 5 == 0 || sum % 11 == 0)
                {
                    isStrong = true;
                }
                Console.WriteLine($"{i} -> {isStrong}");
            }
        }
    }
}
