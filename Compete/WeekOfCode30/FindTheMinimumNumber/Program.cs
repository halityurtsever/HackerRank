using System;

namespace HackerRank.Competes.WeekOfCode30.FindTheMinimumNumber
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int value = Convert.ToInt32(Console.ReadLine());
            string templateLeft = string.Empty;
            string templateMiddle = "int";
            string templateRight = string.Empty;

            for (int i = 1; i < value; i++)
            {
                templateLeft += "min(int, ";
                templateRight += ")";
            }

            Console.WriteLine($"{templateLeft}{templateMiddle}{templateRight}");
        }
    }
}
