using System;
using System.Linq;

namespace T01DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n,n];
            int primaryDiagonal = 0;
            int secondaryDiangonal = 0;

            for (int row = 0; row < n; row++)
            {
                int[] arr = Console.ReadLine().Split()
                    .Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            for (int row = 0; row < n; row++)
            {
                primaryDiagonal += matrix[row, row];
                secondaryDiangonal += matrix[row, n - row - 1];
            }

            Console.WriteLine(Math.Abs(primaryDiagonal-secondaryDiangonal));
        }
    }
}
