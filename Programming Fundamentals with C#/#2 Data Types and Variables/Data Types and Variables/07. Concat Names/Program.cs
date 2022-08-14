using System;

namespace _07._Concat_Names
{
    class Program
    {
        static void Main()
        {
            string name = Console.ReadLine();
            string lastName = Console.ReadLine();
            string symbol = Console.ReadLine();

            Console.WriteLine($"{name}{symbol}{lastName}");
        }
    }
}
