using System;
using System.Linq;

namespace T05SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = ReadArrFromConsole();
            int[,] matrix = new int[input[0], input[1]];
            int maxSum = int.MinValue;
            int mxRow = 0;
            int mxCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] arr = ReadArrFromConsole();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                    if (sum>maxSum)
                    {
                        maxSum = sum;
                        mxRow = row;
                        mxCol = col;
                    }
                }
            }

            Console.WriteLine($"{ matrix[mxRow, mxCol]} {matrix[mxRow, mxCol + 1]}");
            Console.WriteLine($"{ matrix[mxRow + 1, mxCol]} { matrix[mxRow + 1, mxCol + 1]}");
            Console.WriteLine(maxSum);
        }

        private static int[] ReadArrFromConsole()
        {
            return Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
        }
    }
}
