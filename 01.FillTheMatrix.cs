using System;
using System.Globalization;
using System.Threading;

/// Write two programs that fill and print a matrix of size N x N. Filling a matrix in 
/// the regular pattern (top to bottom and left to right) is boring. 

class FillTheMatrix
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int[,] matrix = new int[4, 4];
        GetPatternA(matrix);
        PrintMatrix(matrix);
        Console.WriteLine();
        GetPatternB(matrix);
        PrintMatrix(matrix);

    }

    private static void GetPatternB(int[,] matrix)
    {
        int filler = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (j % 2 == 0)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    filler++;
                    matrix[i, j] = filler;
                }
            }
            else
            {
                for (int i = matrix.GetLength(0)-1; i >= 0; i--)
                {
                    filler++;
                    matrix[i, j] = filler;
                }
            }
        }
    }

    private static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("{0} ", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }

    private static void GetPatternA(int[,] matrix)
    {
        int filler = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                filler++;
                matrix[i, j] = filler;
            }
        }
    }
}
