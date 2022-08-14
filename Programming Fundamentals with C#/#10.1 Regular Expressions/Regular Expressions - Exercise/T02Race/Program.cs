using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace T02Race
{
    class Program
    {
        static void Main(string[] args)
        {
            var patternForName = new Regex(@"(?<name>[A-Za-z+])");
            string patternForDigits = @"(?<digits>\d+)";
            var sumOfDigits = 0;

            Dictionary<string, int> racers = new Dictionary<string, int>();
            var names = Console.ReadLine().Split(", ").ToList();
            var input = Console.ReadLine();

            while (input != "end of race")
            {
                var matchedNames = patternForName.Matches(input);
                var matchedDigits = Regex.Matches(input, patternForDigits);
                var currName = string.Join("", matchedNames);
                var currDigit = string.Join("", matchedDigits);

                sumOfDigits = 0;
                foreach (var digit in currDigit)
                {
                    sumOfDigits += int.Parse(digit.ToString());
                }

                if (names.Contains(currName))
                {
                    if (!racers.ContainsKey(currName))
                    {
                        racers.Add(currName, sumOfDigits);
                    }
                    else
                    {
                        racers[currName] += sumOfDigits;
                    }
                }

                input = Console.ReadLine();
            }

            var winners =
                racers
                    .OrderByDescending(x => x.Value)
                    .Take(3);

            var firstPlace = winners.Take(1);
            var secondPlace = winners
                .OrderByDescending(x => x.Value)
                .Take(2).OrderBy(x => x.Value).Take(1);
            var thirdPlace = winners
                .OrderByDescending(x => x.Value)
                .Take(3).OrderBy(x =>x.Value).Take(1);

            foreach (var first in firstPlace)
            {
                Console.WriteLine($"1st place: {first.Key}");
            }
            foreach (var second in secondPlace)
            {
                Console.WriteLine($"2nd place: {second.Key}");
            }
            foreach (var third in thirdPlace)
            {
                Console.WriteLine($"3rd place: {third.Key}");
            }
        }
    }
}
