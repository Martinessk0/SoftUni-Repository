using System;
using System.Collections.Generic;

namespace T01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main()
        {
            string[] words = Console.ReadLine().Split();
            Dictionary<char, int> counts = new Dictionary<char, int>();
            foreach (var word in words)
            {
                foreach (var c in word)
                {
                    if (counts.ContainsKey(c)) counts[c]++;
                    else counts.Add(c, 1);
                }
            }

            foreach (var count in counts)
            {
                Console.WriteLine($"{count.Key} -> {count.Value}");
            }
        }
    }
}
