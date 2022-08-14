using System;

namespace T02.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            GetSum(input[0], input[1]);
        }

        static void GetSum(string stringOne, string stringTwo)
        {
            int sum = 0;
            int minLenght = Math.Min(stringOne.Length, stringTwo.Length);
            for (int i = 0; i < minLenght; i++)
            {
                sum += stringOne[i] * stringTwo[i];
            }
            string longestLenghtString = stringOne;
            if (longestLenghtString.Length < stringTwo.Length) longestLenghtString = stringTwo;
            for (int i = minLenght; i < longestLenghtString.Length; i++)
            {
                sum += longestLenghtString[i];
            }
            Console.WriteLine(sum);
        }
    }
}
