using System;
using System.Collections.Generic;
using System.Linq;

namespace T07._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> studentsInfo = new Dictionary<string, List<double>>();
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                if (!studentsInfo.ContainsKey(name))
                {
                    studentsInfo.Add(name,new List<double>());
                }
                studentsInfo[name].Add(grade);
            }

            foreach (var student in studentsInfo.OrderByDescending(x => x.Value.Average()))
            {
                if (student.Value.Average()>=4.5)
                {
                    Console.WriteLine($"{student.Key} -> {student.Value.Average():f2}");
                }
            }
            
        }
    }
}
