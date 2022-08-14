using System;

namespace T02.RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split();
            string reapeted = "";
            foreach (var word in array)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    reapeted += word;
                }
            }

            Console.WriteLine(reapeted);
        }
    }
}
