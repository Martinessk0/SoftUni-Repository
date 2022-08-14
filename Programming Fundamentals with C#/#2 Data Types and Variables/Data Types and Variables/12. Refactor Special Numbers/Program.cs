using System;

namespace _12._Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            for (int i = 1; i <= n; i++)
            {
                int number = i;
                int sum = 0;
                while (number > 0)
                {
                    sum += number % 10;
                    number = number / 10;
                }

                bool isStrong = false;

                if ((sum %5==0) || (sum % 7 == 0) || (sum % 11 == 0))
                {
                    isStrong = true;
                }
                Console.WriteLine("{0} -> {1}", i, isStrong);
            }

        }
    }
}
