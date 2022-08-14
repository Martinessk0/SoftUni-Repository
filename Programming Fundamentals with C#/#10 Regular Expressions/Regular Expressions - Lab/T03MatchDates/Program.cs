using System;
using System.Data.Common;
using System.Text.RegularExpressions;

namespace T03MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string datesStrings = Console.ReadLine();
            MatchCollection dates = Regex.Matches(datesStrings,
                @"(?<day>[0-9]{2})(?<separator>[\.\-\/])(?<month>[A-Z][a-z]{2})\k<separator>(?<year>[0-9]{4})");

            foreach (Match date in dates)
            {
                var day = date.Groups["day"].Value;
                var month = date.Groups["month"].Value;
                var year = date.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }

        }
    }
}
