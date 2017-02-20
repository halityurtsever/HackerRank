using System;

namespace HackerRank.Tutorials._30DaysOfCode.ExceptionsStringToInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var input = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(input);
            }
            catch (Exception)
            {
                Console.WriteLine("Bad String");
            }
        }
    }
}
