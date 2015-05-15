using System;
using System.Globalization;
using System.Linq;
using System.Threading;

/// Write a program that reads a rectangular integer matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements. 
/// On the first line, you will receive the rows N and columns M.On the next N lines you will receive each row with its columns.
/// Print the elements of the 3 x 3 square as a matrix, along with their sum.

class MaximalSum
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int[] matrixDimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
        int[,] matrix = new int[matrixDimensions[0], matrixDimensions[1]];
        for (int i = 0; i < matrixDimensions[0]; i++)
        {
            string[] filler = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            for (int j = 0; j < matrixDimensions[1]; j++)
            {
                matrix[i, j] = int.Parse(filler[j]);
            }
        }
        int maxSum = int.MinValue;
        int startI = 0;
        int startJ = 0;
        for (int i = 0; i < matrixDimensions[0] - 2; i++)
        {
            for (int j = 0; j < matrixDimensions[1] - 2; j++)
            {
                int currentMaxSum = matrix[i,j]+matrix[i,j+1]+matrix[i,j+2]+
                                    matrix[i+1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2]+
                                    matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];
                if (currentMaxSum > maxSum)
                {
                    maxSum = currentMaxSum;
                    startI = i;
                    startJ = j;
                }
            }
        }
        Console.WriteLine("Sum = {0}", maxSum);
        for (int i=0; i<3;i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write("{0} ", matrix[startI + i,startJ+j]);
            }
            Console.WriteLine();
        }
    }
}

