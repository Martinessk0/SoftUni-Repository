using System;
using System.Collections.Generic;

namespace _7
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> vloggers = new Dictionary<string, List<string>>();
            Dictionary<string, int[]> userNumberOfFolowers = new Dictionary<string, int[]>();
            
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            while (input[0] != "Statistics")
            {
                string username = input[0];
                string command = input[1];
                if (command == "joined")
                {
                    if (vLog.ContainsKey(new HashSet<string>(){username}) == false)
                    {
                        vLog.Add(new HashSet<string>(){username},new Dictionary<List<string>, List<string>>());
                    }
                }
                else if (command == "followed")
                {
                    string firstUser = input[0];
                    string seconUser = input[2];
                    if (vLog.ContainsKey(firstUser))
                    {
                        
                    }
                }
                input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
