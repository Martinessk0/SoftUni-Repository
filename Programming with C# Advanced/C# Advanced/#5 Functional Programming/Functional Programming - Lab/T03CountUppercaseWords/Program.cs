using System;
using System.Linq;

namespace T03CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> predicate = str => str[0] == str.ToUpper()[0];
            string[] text = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(x => predicate(x))
                .ToArray();
            foreach (var word in text)
            {
                Console.WriteLine(word);
            }
        }
    }
}
