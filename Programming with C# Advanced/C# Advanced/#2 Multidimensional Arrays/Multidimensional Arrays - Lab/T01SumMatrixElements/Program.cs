using System;
using System.Linq;

namespace T01SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = ReadArrFromConsole();
            int row = input[0];
            int col = input[1];
            int sum = 0;
            int[,] matrix = new int[row,col];

            for (int i = 0; i < row; i++)
            {
                int[] arr = ReadArrFromConsole();
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = arr[j];
                    sum += arr[j];
                }
            }
            Console.WriteLine(row);
            Console.WriteLine(col);
            Console.WriteLine(sum);
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
