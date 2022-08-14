using System;
using System.Text.RegularExpressions;

namespace T01MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\b([A-Z]{1}[a-z]+) ([A-Z]{1}[a-z]+)\b";
            string names = Console.ReadLine();
            MatchCollection matchedNames = Regex.Matches(names, regex);
            foreach (Match match in matchedNames)
            {
                Console.Write($"{match.Value} ");
            }
            Console.WriteLine();
        }
    }
}
