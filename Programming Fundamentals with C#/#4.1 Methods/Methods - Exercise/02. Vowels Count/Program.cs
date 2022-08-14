using System;

namespace _02._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower(); ;
            Vowels(input);
        }

        static void Vowels(string input)
        {
            int count = 0;
            foreach (var vowels in input)
            {
                if ("aeoui".Contains(vowels))
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
