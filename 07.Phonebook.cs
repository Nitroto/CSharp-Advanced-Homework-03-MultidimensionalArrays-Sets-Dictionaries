using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

/// Write a program that receives some info from the console about people and their phone numbers. 
/// You are free to choose the manner in which the data is entered; each entry should have just one 
/// name and one number (both of them strings). After filling this simple phonebook, upon receiving 
/// the command "search", your program should be able to perform a search of a contact by name and print
/// her details in format "{name} -> {number}". In case the contact isn't found, print "Contact {name} does not exist."

class Phonebook
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Dictionary<string, List<string>> phonebook = new Dictionary<string, List<string>>();
        string[] command = Console.ReadLine().Split('-').ToArray();
        while (command[0] != "search")
        {
            string key = command[0];
            string number = command[1];
            if (phonebook.ContainsKey(key))
            {
                phonebook[key].Add(number);
            }
            else
            {
                phonebook.Add(key, new List<string>());
                phonebook[key].Add(number);
            }
            command = Console.ReadLine().Split('-').ToArray();
        }
        command = Console.ReadLine().Split('-').ToArray();
        while (command[0] != string.Empty)
        {
            string key = command[0];
            if (phonebook.ContainsKey(key))
            {
                for (int i = 0; i < phonebook[key].Count; i++)
                {
                    Console.WriteLine("{0} -> {1}", key, phonebook[key][i]);
                }
            }
            else
            {
                Console.WriteLine("Contact {0} does not exist", key);
            }
            command = Console.ReadLine().Split('-').ToArray();
        }
    }
}
