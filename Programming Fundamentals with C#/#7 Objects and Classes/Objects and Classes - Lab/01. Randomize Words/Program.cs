using System;

namespace _01._Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Random rnd = new Random();

            for (int i = 0; i < input.Length; i++)
            {
                int position = rnd.Next(input.Length);
                string temp = input[i];
                input[i] = input[position];
                input[position] = temp;
            }

            Console.WriteLine(string.Join(Environment.NewLine,input));
        }
    }
}
