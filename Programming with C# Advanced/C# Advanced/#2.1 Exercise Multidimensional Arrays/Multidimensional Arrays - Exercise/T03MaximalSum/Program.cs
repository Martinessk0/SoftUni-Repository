using System;
using System.Linq;
using System.Numerics;

namespace T03MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[,] matrix = new int[input[0], input[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] arr = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = arr[col];
                }
            }
            int maxSum = int.MinValue;
            int mxRow = 0;
            int mxCol = 0;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                              + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                              + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (maxSum<sum)
                    {
                        maxSum = sum;
                        mxRow = row;
                        mxCol = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{ matrix[mxRow, mxCol]} {matrix[mxRow,mxCol+1]} {matrix[mxRow,mxCol+2]}");
            Console.WriteLine($"{ matrix[mxRow+1, mxCol]} {matrix[mxRow+1,mxCol+1]} {matrix[mxRow+1,mxCol+2]}");
            Console.WriteLine($"{ matrix[mxRow+2, mxCol]} {matrix[mxRow+2,mxCol+1]} {matrix[mxRow+2,mxCol+2]}");
        }
    }
}
