using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets of several 
/// neighbour elements located on the same line, column or diagonal. Write a program that finds the 
/// longest sequence of equal strings in the matrix.


class SequenceInMatrix
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int[] matrixDimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
        string[,] matrix = new string[matrixDimensions[0], matrixDimensions[1]];
        for (int i = 0; i < matrixDimensions[0]; i++)
        {
            string[] filler = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            for (int j = 0; j < matrixDimensions[1]; j++)
            {
                matrix[i, j] = filler[j];
            }
        }
        string maxElement = string.Empty;
        int maxCount = int.MinValue;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int horisontal = CountHorisontal(matrix, i, j);
                int vertical = CountVertical(matrix, i, j);
                int rightDiagonal = CountRight(matrix, i, j);
                int leftDiagonal = CountLeft(matrix, i ,j);
                if (maxCount < horisontal)
                {
                    maxCount = horisontal;
                    maxElement = matrix[i, j];
                }
                if (maxCount < vertical)
                {
                    maxCount = vertical;
                    maxElement = matrix[i, j];

                }
                if (maxCount < rightDiagonal)
                {
                    maxCount = rightDiagonal;
                    maxElement = matrix[i, j];
                }
                if (maxCount < leftDiagonal)
                {
                    maxCount = leftDiagonal;
                    maxElement = matrix[i, j];

                }
            }
        }
        for (int i = 0; i < maxCount; i++)
        {
            if (i != maxCount - 1)
            {
                Console.Write("{0}, ", maxElement);
            }
            else
            {
                Console.WriteLine("{0}", maxElement);
            }


        }
    }

    private static int CountLeft(string[,] matrix, int startI, int startJ)
    {
        int count = 1;
        for (int i = startI, j = startJ; i >= 1; i--, j--)
        {
            bool  validNext= j >= 1 ? true : false;
            if (validNext)
            {
                if (matrix[i, j] == matrix[i - 1, j - 1])
                {
                    count++;
                }
                else
                {
                    return count;
                }
            }
            else
            {
                return count;
            }
        }
        return count;
    }

    private static int CountRight(string[,] matrix, int startI, int startJ)
    {
        int count = 1;
        for (int i = startI, j = startJ; i < matrix.GetLength(0) - 1; i++, j++)
        {
            bool validNext = j < matrix.GetLength(1) - 1 ? true : false;
            if (validNext)
            {
                if (matrix[i, j] == matrix[i + 1, j + 1])
                {
                    count++;
                }
                else
                {
                    return count;
                }
            }
            else
            {
                return count;
            }
        }
        return count;
    }

    private static int CountVertical(string[,] matrix, int startI, int startJ)
    {
        int count = 1;
        for (int i = startI; i < matrix.GetLength(0); i++)
        {
            bool validNext = i < matrix.GetLength(0) - 1 ? true : false;
            if (validNext)
            {
                if (matrix[i, startJ] == matrix[i + 1, startJ])
                {
                    count++;
                }
                else
                {
                    return count;
                }
            }
            else
            {
                return count;
            }
        }
        return count;
    }

    private static int CountHorisontal(string[,] matrix, int startI, int startJ)
    {
        int count = 1;
        for (int j = startJ; j < matrix.GetLength(1); j++)
        {
            bool validNext = j < matrix.GetLength(1) - 1 ? true : false;
            if (validNext)
            {
                if (matrix[startI, j] == matrix[startI, j + 1])
                {
                    count++;
                }
                else
                {
                    return count;
                }
            }
            else
            {
                return count;
            }
        }
        return count;
    }
}
