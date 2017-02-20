using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = Convert.ToInt32(Console.ReadLine());
            var result = CalculateFactorial(number);

            Console.WriteLine(result);
            Console.ReadLine();
        }

        private static int CalculateFactorial(int number)
        {
            if (number <= 0)
            {
                return 1;
            }
            return number * CalculateFactorial(number - 1);
        }
    }
}
