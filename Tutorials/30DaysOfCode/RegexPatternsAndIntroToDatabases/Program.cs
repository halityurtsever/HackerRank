using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HackerRank.Tutorials._30DaysOfCode.RegexPatternsAndIntroToDatabases
{
    class Program
    {
        static void Main(string[] args)
        {
            int arraySize = Convert.ToInt32(Console.ReadLine());
            Dictionary<string, string> mailDB = new Dictionary<string, string>();
            List<string> orderedNames = new List<string>();

            //read data and map it into the dictionary
            for (int i = 0; i < arraySize; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ');
                string name = tokens[0];
                string mail = tokens[1];
                if (!mailDB.ContainsKey(mail))
                {
                    mailDB.Add(mail, name);
                }
            }

            Regex nameRegex = new Regex("[a-z]{1,20}");
            Regex mailRegex = new Regex("[a-z.]{1,40}@gmail.com");

            foreach (var item in mailDB)
            {
                if (nameRegex.Match(item.Value).Value == item.Value &&
                    mailRegex.Match(item.Key).Value == item.Key)
                {
                    orderedNames.Add(item.Value);
                }
            }

            //order list
            bool isSwapped = true;
            while (isSwapped)
            {
                isSwapped = false;

                for (int i = 0; i < orderedNames.Count - 1; i++)
                {
                    if (orderedNames[i].CompareTo(orderedNames[i + 1]) == 1)
                    {
                        var temp = orderedNames[i];
                        orderedNames[i] = orderedNames[i + 1];
                        orderedNames[i + 1] = temp;
                        isSwapped = true;
                    }
                }
            }

            //print list
            foreach (var item in orderedNames)
            {
                Console.WriteLine(item);
            }
        }
    }
}
