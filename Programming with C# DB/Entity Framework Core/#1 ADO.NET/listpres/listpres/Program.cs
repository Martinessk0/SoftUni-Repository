using System;
using System.Collections.Generic;
using System.Linq;

namespace listpres
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int sum = 0;
            int countBelowDiagonal = 0;
            for (int row = 0; row < n; row++)
            {
                int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = arr[col];
                }
            }
            Console.WriteLine(new string('-',20));
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (row > col)
                    {
                        if (matrix[row, col] % 2 == 0)
                        {
                            countBelowDiagonal++;
                        }
                    }
                    sum += matrix[row, col];
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"countBelowDiagonal: {countBelowDiagonal}");
        }
    }
}

