using System;
using System.Collections.Generic;
using System.Linq;

namespace T05SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string snake = Console.ReadLine();
            char[,] matrix = new char[input[0], input[1]];
            Queue<char> queue = new Queue<char>();
            int counter = 0;   
            int capacity = input[0] * input[1];

            for (int i = 0; i < snake.Length; i++)
            {
                queue.Enqueue(snake[i]);
                counter++;
                if (counter == capacity) break;
                if (i==snake.Length-1) i = -1;
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = queue.Dequeue();
                    }
                }
                else if (row % 2 != 0 )
                {
                    for (int col = matrix.GetLength(1)-1; col >=0; col--)
                    {
                        matrix[row, col] = queue.Dequeue();
                    }
                }
            }
            PrintMatrix(matrix);

        }

        private static char[,] PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row,col]}");
                }
                Console.WriteLine();
            }

            return matrix;
        }
    }
}
