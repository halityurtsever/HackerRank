using System;

namespace HackerRank.Tutorials._30DaysOfCode.LetsReview
{
    class Program
    {
        static void Main(string[] args)
        {
            int query = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < query; i++)
            {
                var input = Console.ReadLine();

                var oddResult = string.Empty;
                var evenResult = string.Empty;

                for (int j = 0; j < input.Length; j++)
                {
                    if (j % 2 == 0)
                        evenResult += input[j];
                    else
                        oddResult += input[j];
                }

                Console.WriteLine($"{evenResult} {oddResult}");
            }
        }
    }
}
