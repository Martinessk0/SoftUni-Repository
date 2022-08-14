using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace T02MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var phones = Console.ReadLine();
            MatchCollection phoneMatches = Regex.Matches(phones, @"(\+359 2 \d{3} \d{4}\b)|(\+ ?359-2-\d{3}-\d{4}\b)");
            //foreach (Match match in phoneMatches)
            //{
            //    Console.Write($"{match.Value}, ");
            //}
            var matchedPhones = phoneMatches.Cast<Match>().Select(a => a.Value.Trim()).ToArray();

            Console.WriteLine(string.Join(", ", matchedPhones));
        }
    }
}
