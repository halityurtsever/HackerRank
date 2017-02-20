﻿using System;

namespace HackerRank.Tracks.DataStructures.Arrays.SparseArrays
{
    public class Program_SparseArrays
    {
        static void Main()
        {
            //read input count and input values
            int inputCount = Convert.ToInt32(Console.ReadLine());
            string[] inputs = new string[inputCount];

            for (int i = 0; i < inputCount; i++)
            {
                inputs[i] = Console.ReadLine();
            }

            //read query count and query values
            int queryCount = Convert.ToInt32(Console.ReadLine());
            string[] queries = new string[queryCount];

            for (int i = 0; i < queryCount; i++)
            {
                queries[i] = Console.ReadLine();
            }

            //find matches
            for (int i = 0; i < queryCount; i++)
            {
                var matchCount = 0;
                for (int j = 0; j < inputCount; j++)
                {
                    if (inputs[j] == queries[i])
                    {
                        matchCount++;
                    }
                }
                Console.WriteLine(matchCount);
            }
        }
    }
}
