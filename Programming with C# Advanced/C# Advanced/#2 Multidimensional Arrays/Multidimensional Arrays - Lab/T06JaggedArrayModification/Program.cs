﻿using System;
using System.Linq;

namespace T06JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] jagged = new int[n][];
            for (int i = 0; i < n; i++)
            {
                jagged[i] = ReadArrFromConsole();
            }
            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] tokens = command.Split();
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);
                if (row <0 || row >=n || col <0 || col >= jagged[row].Length)
                {
                    Console.WriteLine($"Invalid coordinates");
                    command = Console.ReadLine();
                    continue;
                }

                switch (tokens[0])
                {
                    case "Add":
                        jagged[row][col] += value;
                        break;
                    case "Subtract":
                        jagged[row][col] -= value;
                        break;
                }
                command = Console.ReadLine();
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(string.Join(" ",jagged[i]));
            }
        }

        private static int[] ReadArrFromConsole()
        {
            return Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
        }
    }
}
