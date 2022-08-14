using System;

namespace T04.CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string encrypted = "";
            foreach (var words in input)
            {
                encrypted += (char)(words + 3);
            }
            Console.WriteLine(encrypted);
        }
    }
}
