using System;
using System.Text;

namespace T06.ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            char previousChar = text[0];
            Console.Write(previousChar);
            for (int i = 1; i < text.Length; i++)
            {
                char currChar = text[i];
                if (previousChar!=currChar)
                {
                    previousChar = currChar;
                    Console.Write(previousChar);
                }
            }
        }
    }
}
