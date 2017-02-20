using System;

namespace HackerRank.Tutorials._30DaysOfCode.Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var arraySize = Convert.ToInt32(Console.ReadLine());
            var arrayItem = Console.ReadLine().Split(' ');

            for (int i = arraySize -1; i >= 0; i--)
            {
                Console.Write(arrayItem[i] + " ");
            }
        }
    }
}
