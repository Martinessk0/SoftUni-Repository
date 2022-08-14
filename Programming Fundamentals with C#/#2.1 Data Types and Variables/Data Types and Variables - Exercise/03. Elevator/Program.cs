using System;

namespace _03._Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            double persons = double.Parse(Console.ReadLine());
            double capacity = double.Parse(Console.ReadLine());

            double courses =Math.Ceiling(persons / capacity);

            Console.WriteLine(courses);
        }
    }
}
