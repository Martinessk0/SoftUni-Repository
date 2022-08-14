using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayerHand = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondPlayerHand = Console.ReadLine().Split().Select(int.Parse).ToList();
            while (true)
            {
                if (firstPlayerHand[0] > secondPlayerHand[0])
                {
                    firstPlayerHand.Add(firstPlayerHand[0]);
                    firstPlayerHand.Add(secondPlayerHand[0]);
                }
                else if (secondPlayerHand[0] > firstPlayerHand[0])
                {
                    secondPlayerHand.Add(secondPlayerHand[0]);
                    secondPlayerHand.Add(firstPlayerHand[0]);
                }
                firstPlayerHand.Remove(firstPlayerHand[0]);
                secondPlayerHand.Remove(secondPlayerHand[0]);
                if (firstPlayerHand.Count == 0)
                {
                    Console.WriteLine($"Second player wins! Sum: {secondPlayerHand.Sum()}");
                    break;
                }

                if (secondPlayerHand.Count == 0)
                {
                    Console.WriteLine($"First player wins! Sum: {firstPlayerHand.Sum()}");
                    break;
                }
            }


        }
    }
}
