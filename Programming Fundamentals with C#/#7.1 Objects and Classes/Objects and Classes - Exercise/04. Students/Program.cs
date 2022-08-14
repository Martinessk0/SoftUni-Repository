using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
    class Program
    {
        class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public double Grade { get; set; }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();
            for (int i = 0; i < n; i++)
            {
                string[] studentInfo = Console.ReadLine().Split();
                Student student = new Student()
                {
                    FirstName = studentInfo[0],
                    LastName = studentInfo[1],
                    Grade = double.Parse(studentInfo[2])
                };
                students.Add(student);
            }

            foreach (var student in students.OrderByDescending(x =>x.Grade))
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }
        }
    }
}
