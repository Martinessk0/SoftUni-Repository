using System;
using System.Collections.Generic;

namespace _05._Students_2._0
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
                string firstName = cmd[0];
                string lastName = cmd[1];
                int age = int.Parse(cmd[2]);
                string homeTown = cmd[3];
                if (IsStudentExisting(students, firstName, lastName))
                {
                }
                else
                {
                    Student student = new Student();
                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Age = age;
                    student.HomeTown = homeTown;
                    students.Add(student);
                }
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

        static bool IsStudentExisting(List<Student> students, string firstName, string lastName)
        {
            foreach (var student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
