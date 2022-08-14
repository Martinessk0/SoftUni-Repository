using System;
using System.Collections.Generic;

namespace _04._Students
{
    class Program
    {
        class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string HomeTown { get; set; }
        }

        static void Main(string[] args)
        {
            string[] cmd = Console.ReadLine().Split();
            List<Student> students = new List<Student>();

            while (cmd[0] != "end")
            {
                Student student = new Student();
                student.FirstName = cmd[0];
                student.LastName = cmd[1];
                student.Age = int.Parse(cmd[2]);
                student.HomeTown = cmd[3];
                students.Add(student);

                cmd = Console.ReadLine().Split();
            }
            string town = Console.ReadLine();
            foreach (var student in students)
            {
                if (student.HomeTown == town)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }
}
