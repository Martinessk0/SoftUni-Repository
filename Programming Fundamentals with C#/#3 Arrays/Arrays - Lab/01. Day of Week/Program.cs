using System;

namespace _01._Day_of_Week
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[] dayOFWeek = new string[]
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };
            if (n>=1 && n<=7)
            {
                Console.WriteLine($"{dayOFWeek[n-1]}");
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }

        }
    }
}
