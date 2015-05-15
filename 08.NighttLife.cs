using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

/// Being a nerd means writing programs about night clubs instead of actually going to ones. 
/// Spiro is a nerd and he decided to summarize some info about the most popular night clubs around 
/// the world. He's come up with the following structure – he'll summarize the data by city, each city
///  will have a list of venues and each venue will have a list of performers. Help him finish the program, 
/// so he can stop staring at the computer screen and go get himself a cold beer.
/// You'll receive the input from the console. There will be an arbitrary number of lines until you 
/// receive the string "END". Each line will contain data in format: "city;venue;performer". If either city, 
/// venue or performer don't exist yet in the database, add them.If either the city and/or venue exist, update 
/// their info.Cities should remain in the order in which they have been received, venues should be sorted 
/// alphabetically and performers should by unique(per venue) and also sorted alphabetically.
/// Print the data by listing the cities and for each city its venues (on a new line starting with "->") and 
/// performers(separated by comma and space).

class NightLife
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Dictionary<string, Dictionary<string, List<string>>> events = new Dictionary<string, Dictionary<string, List<string>>>();
        string[] command = Console.ReadLine().Split(';').ToArray();
        while (command[0] != "END")
        {
            string place = command[0];
            string venue = command[1];
            string performer = command[2];
            if (events.ContainsKey(place))
            {
                if (events[place].ContainsKey(venue))
                {
                    if (!events[place][venue].Contains(performer))
                    {
                        events[place][venue].Add(performer);
                    }
                }
                else
                {
                    events[place].Add(venue, new List<string>());
                    events[place][venue].Add(performer);
                }
            }
            else
            {
                events.Add(place, new Dictionary<string, List<string>>());
                events[place].Add(venue, new List<string>());
                events[place][venue].Add(performer);
            }
            command = Console.ReadLine().Split(';').ToArray();
        }
        foreach (KeyValuePair<string, Dictionary<string, List<string>>> place in events)
        {
            Console.WriteLine("{0}", place.Key);
            foreach (KeyValuePair<string, List<string>> venue in place.Value)
            {
                Console.Write("-> {0}: ", venue.Key);
                venue.Value.Sort();
                for (int i = 0; i < venue.Value.Count; i++)
                {
                    if (i != venue.Value.Count - 1)
                    {
                        Console.Write("{0}, ", venue.Value[i]);
                    }
                    else
                    {
                        Console.WriteLine("{0}", venue.Value[i]);
                    }
                }
            }
        }
    }
}