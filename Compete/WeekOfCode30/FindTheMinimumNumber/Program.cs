using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTheMinimumNumber
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
