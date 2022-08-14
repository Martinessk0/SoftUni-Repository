using System;

namespace T04.TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();

            foreach (var bannedWord in bannedWords)
            {
                int lenght = bannedWord.Length;
                string filter = "";
                for (int i = 0; i < lenght; i++)
                {
                    filter += "*";
                }
                text = text.Replace(bannedWord, filter);
            }

            Console.WriteLine(text);
        }
    }
}
