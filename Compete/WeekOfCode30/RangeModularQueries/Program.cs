using System;

namespace HackerRank.Competes.WeekOfCode30.RangeModularQueries
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var initials = Console.ReadLine().Split(' ');
            int arraySize = Convert.ToInt32(initials[0]);
            int querySize = Convert.ToInt32(initials[1]);
            int[] array = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            for (int i = 0; i < querySize; i++)
            {
                var queryData = Console.ReadLine().Split(' ');
                int left = Convert.ToInt32(queryData[0]);
                int right = Convert.ToInt32(queryData[0]);
                int mod = Convert.ToInt32(queryData[0]);
                int remain = Convert.ToInt32(queryData[0]);
                int count = 0;

                for (int j = left; j <= right; j++)
                {
                    if (array[j] % mod == remain)
                    {
                        count++;
                    }
                }

                Console.WriteLine(count);
            }
        }
    }
}
