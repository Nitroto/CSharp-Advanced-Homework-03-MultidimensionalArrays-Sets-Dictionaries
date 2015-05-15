using System;
using System.Globalization;
using System.Linq;
using System.Threading;


/// Write a program which reads a string matrix from the console and performs certain operations with its elements. 
/// User input is provided like in the problem above – first you read the dimensions and then the data. Remember, 
/// you are not required to do this step first, you may add this functionality later.  
/// Your program should then receive commands in format: "swap x1 y1 x2 y2" where x1, x2, y1, y2 are coordinates 
/// in the matrix.In order for a command to be valid, it should start with the "swap" keyword along with four valid 
/// coordinates (no more, no less). You should swap the values at the given coordinates(cell[x1, y1] with cell[x2, y2]) 
/// and print the matrix at each step(thus you'll be able to check if the operation was performed correctly). 

class MatrixShuffling
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int row = int.Parse(Console.ReadLine());
        int col = int.Parse(Console.ReadLine());
        string[,] matrix = new string[row, col];
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                matrix[i, j] = Console.ReadLine();
            }
        }
        string[] command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        while (command[0] != "END")
        {
            string temp = string.Empty;
            int x1 = int.Parse(command[1]);
            int y1 = int.Parse(command[2]);
            int x2 = int.Parse(command[3]);
            int y2 = int.Parse(command[4]);
            if (x1 < matrix.GetLength(0) && y1 < matrix.GetLength(1) && x2 < matrix.GetLength(0) && y2 < matrix.GetLength(1))
            {
                temp = matrix[x1, y1];
                matrix[x1, y1] = matrix[x2, y2];
                matrix[x2, y2] = temp;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write("{0} ", matrix[i,j]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
            command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        }
    }
}
