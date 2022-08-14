using System;
using System.Linq;

namespace T06JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] jagged = new double[n][];    
            for (int i = 0; i < n; i++)
            {
                jagged[i] = ReadArrayFromConsole();
            }

            for (int row = 0; row < jagged.GetLength(0)-1; row++)
            {
                if (!(jagged[row].Length == jagged[row+1].Length))
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        jagged[row][col] = jagged[row][col] / 2;
                    }
                    for (int col = 0; col < jagged[row+1].Length; col++)
                    {
                        jagged[row + 1][col] = jagged[row + 1][col] / 2;
                    }

                }
                else
                {
                    for (int col = 0; col < jagged[row].GetLength(0); col++)
                    {
                        jagged[row][col] = jagged[row][col] * 2;
                        jagged[row + 1][col] = jagged[row + 1][col] * 2;
                    }
                }
            }

            string input = Console.ReadLine();
            while (input !="End")
            {
                string[] tokens = Console.ReadLine().Split();
                string cmd = tokens[0];
                if (cmd == "Add")
                {
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);
                    int value = int.Parse(tokens[3]);

                    jagged[row][col] += value;
                }
                else if (cmd == "Subtract")
                {
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);
                    int value = int.Parse(tokens[3]);

                    jagged[row][col] -= value;
                }
                tokens = Console.ReadLine().Split();
                if (tokens[0]=="End")
                {
                    break;
                }
            }
            PrintJagged(jagged);
        }

        private static void PrintJagged(double[][] jagged)
        {
            for (int i = 0; i < jagged.GetLength(0); i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.Write($"{jagged[i][j]} ");
                }
                Console.WriteLine();
            }
        }

        private static double[] ReadArrayFromConsole()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
        }
    }
}
