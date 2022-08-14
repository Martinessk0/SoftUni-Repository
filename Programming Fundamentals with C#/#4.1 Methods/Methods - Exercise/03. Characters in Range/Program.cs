using System;

namespace _03._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            char temp = ' ';
            if ((int)second < (int)first)
            {
                temp = first;
                first = second;
                second = temp;
            }
            PrintChar(first,second);

        }

        static void PrintChar(char first, char second)
        {
            for (int i = first+1; i <second; i++)
            {
                Console.Write($"{(char)i} ");
            }
        }
    }
}
