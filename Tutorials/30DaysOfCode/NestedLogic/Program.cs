using System;

namespace HackerRank.Tutorials._30DaysOfCode.NestedLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            var actualReturn = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
            var expectedReturn = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);

            int fine = CalculateFine(expectedReturn, actualReturn);

            Console.WriteLine(fine);
        }

        private static int CalculateFine(int[] expectedDate, int[] actualDate)
        {
            int actualDay = actualDate[0];
            int actualMonth = actualDate[1];
            int actualYear = actualDate[2];

            int expectedDay = expectedDate[0];
            int expectedMonth = expectedDate[1];
            int expectedYear = expectedDate[2];

            if (actualYear < expectedYear)
            {
                return 0;
            }

            if (actualYear == expectedYear)
            {
                if (actualMonth < expectedMonth)
                {
                    return 0;
                }

                if (actualMonth == expectedMonth)
                {
                    //no fine will be charged
                    if (actualDay <= expectedDay)
                    {
                        return 0;
                    }

                    //15 fine will be charged per day
                    return (actualDay - expectedDay) * 15;
                }

                //500 fine will be charged per month
                return (actualMonth - expectedMonth) * 500;
            }

            //fixed 10000 fine will be charged
            return 10000;
        }
    }
}