using System;
using System.Collections.Generic;
using System.Linq;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> countSymbols = new Dictionary<char, int>();
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                if (countSymbols.ContainsKey(input[i]) == false) 
                {
                    countSymbols.Add(input[i],1);
                }
                else if (countSymbols.ContainsKey(input[i]))
                {
                    countSymbols[input[i]]++;
                }
            }

            foreach (var countSymbol in countSymbols.OrderBy(x =>x.Key))
            {
                Console.WriteLine($"{countSymbol.Key}: {countSymbol.Value} time/s");
            }
        }
    }
}
