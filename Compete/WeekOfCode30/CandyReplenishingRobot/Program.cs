using System;

namespace HackerRank.Competes.WeekOfCode30.CandyReplenishingRobot
{
    public class Program
    {
        static void Main(string[] args)
        {
            //read initial values
            var initalValues = Console.ReadLine().Split(' ');
            int candyValue = Convert.ToInt32(initalValues[0]);
            int partyTime = Convert.ToInt32(initalValues[1]);
            int[] candyPicks = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);

            int totalRobotAdded = 0;
            int currentCandies = candyValue;

            for (int i = 0; i < partyTime - 1; i++)
            {
                currentCandies -= candyPicks[i];
                if (currentCandies < 5)
                {
                    totalRobotAdded += candyValue - currentCandies;
                    currentCandies = candyValue;
                }
            }

            Console.WriteLine(totalRobotAdded);
        }
    }
}
