using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace T08._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();
            string[] cmd = Console.ReadLine().Split(" -> ");
            while (cmd[0] != "End")
            {
                string company = cmd[0];
                string personId = cmd[1];
                if (!companies.ContainsKey(company))
                {
                    companies.Add(company, new List<string>());
                }
                if (!companies[company].Contains(personId))
                {
                    companies[company].Add(personId);
                }
                cmd = Console.ReadLine().Split(" -> ");
            }

            foreach (var company in companies.OrderBy(x => x.Key))
            {
                Console.WriteLine(company.Key);
                foreach (var ids in company.Value)
                {
                    Console.WriteLine($"-- {ids}");
                }
            }
        }
    }
}
