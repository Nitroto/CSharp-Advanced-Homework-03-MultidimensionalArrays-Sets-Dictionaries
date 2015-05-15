using System;
using System.Globalization;
using System.Threading;

/// Write a program that reads some text from the console and counts the occurrences of each character in it. 
/// Print the results in alphabetical (lexicographical order).

class CountSymbols
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        char[] userInput = Console.ReadLine().ToCharArray();
        int[] frequencies = new int[char.MaxValue];
        foreach (char letter in userInput)
        {
            frequencies[letter]++;
        }
        for (int i = 0; i < char.MaxValue; i++)
        {
            if (frequencies[i] > 0)
            {
                Console.WriteLine("{0} -> {1} {2}", (char)i, frequencies[i], frequencies[i] > 1 ? "times" : "time");
            }
        }
    }
}
