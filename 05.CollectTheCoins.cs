using System;
using System.Globalization;
using System.Threading;

/// Working with multidimensional arrays can be (and should be) fun. Let's make a game out of it.
/// You receive the layout of a board from the console.Assume it will always have 4 rows which you'll 
/// get as strings, each on a separate line. Each character in the strings will represent a cell on the board. 
/// Note that the strings may be of different length.
/// You are the player and start at the top-left corner (that would be position [0, 0] on the board). 
/// On the fifth line of input you'll receive a string with movement commands which tell you where to go 
/// next, it will contain only these four characters – '>' (move right), '<' (move left), '^' (move up) and
/// 'v' (move down).  You need to keep track of two types of events – collecting coins (represented by the 
/// symbol '$' of course) and hitting the walls of the board (when the player tries to move off the board to 
/// invalid coordinates). When all moves are over, print the amount of money collected and the number of walls hit.


class CollectTheCoins
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        char[][] board = new char[4][];
        for (int i = 0; i < board.Length; i++)
        {
            board[i] = Console.ReadLine().ToCharArray();
        }
        char[] commands = Console.ReadLine().ToCharArray();
        int coins = 0;
        int hits = 0;
        int prevX = 0;
        int prevY = 0;
        foreach (char move in commands)
        {
            int x = 0;
            int y = 0;
            switch (move)
            {
                case '>': x++; break;
                case '<': x--; break;
                case 'V': y++; break;
                case '^': y--; break;
            }
            x += prevX;
            y += prevY;
            if (y > 3 || y < 0)
            {
                hits++;
                y = prevY;
            }
            else if (x >= board[y].Length)
            {
                hits++;
                y = prevY;
            }
            if (x >= board[y].Length || x < 0)
            {
                hits++;
                x = prevX;
            }
            if (board[y][x] == '$')
            {
                coins++;
            }
            prevX = x;
            prevY = y;
        }
        Console.WriteLine("Coins collected: {0}\n\rWalls hit: {1}", coins, hits);
    }
}
