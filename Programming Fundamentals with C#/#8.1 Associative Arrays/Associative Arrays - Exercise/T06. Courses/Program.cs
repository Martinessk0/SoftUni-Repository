using System;
using System.Collections.Generic;
using System.Linq;

namespace T06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();
            string[] cmd = Console.ReadLine().Split(" : ");
            while (cmd[0] != "end")
            {
                string courseName = cmd[0];
                string studentName = cmd[1];
                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName, new List<string>());
                }
                courses[courseName].Add(studentName);
                cmd = Console.ReadLine().Split(" : ");
            }

            foreach (var course in courses.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                foreach (var name in course.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {name}");
                }
            }
        }
    }
}
