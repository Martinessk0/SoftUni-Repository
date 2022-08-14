using System;

namespace _06._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            PrintMiddleCharacters(input);
        }

        static void PrintMiddleCharacters(string text)
        {
            if (text.Length % 2 != 0)
            {
                Console.WriteLine(text[text.Length/2]);
            }
            else
            {
                Console.Write(text[text.Length / 2 - 1]);
                Console.Write(text[text.Length / 2]);
            }

            Console.WriteLine();
        }

    }
}
