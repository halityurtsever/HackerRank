using System;

namespace HackerRank.Tutorials._30DaysOfCode.RunningTimeAndComplexity
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isPrime;
            int testCases = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < testCases; i++)
            {
                isPrime = true;
                var number = Convert.ToDouble(Console.ReadLine());

                if (number == 1)
                {
                    Console.WriteLine("Not prime");
                    continue;
                }

                int squareRoot = Convert.ToInt32(Math.Round(Math.Sqrt(number)));

                for (int j = squareRoot; j > 1; j--)
                {
                    if (number % j == 0)
                    {
                        isPrime = false;
                        Console.WriteLine("Not prime");
                        break;
                    }
                }

                if (isPrime)
                {
                    Console.WriteLine("Prime");
                }
            }
        }
    }
}
