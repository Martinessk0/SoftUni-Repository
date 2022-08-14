using System;
using System.Collections.Generic;

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> wardrobe = new Dictionary<string, List<string>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" -> ");
                string[] clothes = input[1]
                    .Split(",");
                if (wardrobe.ContainsKey(input[0]) == false)
                {
                    wardrobe.Add(input[0],new List<string>());
                }
                else if (wardrobe.ContainsKey(input[0]))
                {
                    for (int j = 0; j < clothes.Length; j++)
                    {
                        wardrobe[input[0]].Add(clothes[j]);
                    }
                }
            }
        }
    }
}
