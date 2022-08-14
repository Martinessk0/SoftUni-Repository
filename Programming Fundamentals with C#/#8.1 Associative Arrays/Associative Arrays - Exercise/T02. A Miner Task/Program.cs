using System;
using System.Collections.Generic;

namespace T02._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, int> resources = new Dictionary<string, int>();
            while (input != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());
                if (resources.ContainsKey(input)) resources[input] += quantity;
                else resources.Add(input, quantity);
                input = Console.ReadLine();
            }

            foreach (var resource in resources)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}
