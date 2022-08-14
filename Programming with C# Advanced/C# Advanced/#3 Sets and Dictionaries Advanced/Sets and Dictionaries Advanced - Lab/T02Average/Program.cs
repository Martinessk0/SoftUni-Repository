using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace T02Average
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> studentsGrades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = cmd[0];
                decimal grade = decimal.Parse(cmd[1]);

                if (studentsGrades.ContainsKey(name))
                {
                    studentsGrades[name].Add(grade);
                }
                else
                {
                    studentsGrades.Add(name, new List<decimal>()
                    {
                        grade
                    });
                }
            }

            foreach (var student in studentsGrades)
            {
                Console.Write($"{student.Key} -> ");
                foreach (var grades in student.Value)
                {
                    Console.Write($"{grades:f2} ");
                }

                Console.Write($"(avg: {student.Value.Average():f2})");
                Console.WriteLine();
            }
        }
    }
}
