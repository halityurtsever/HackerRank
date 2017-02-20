using System;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());
            AdvancedArithmetic myCalculator = new Calculator();
            int sum = myCalculator.divisorSum(n);
            Console.WriteLine("I implemented: AdvancedArithmetic\n" + sum);
        }
    }

    internal class Calculator : AdvancedArithmetic
    {
        public int divisorSum(int n)
        {
            var total = 0;
            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0)
                {
                    total += i;
                }
            }
            return total;
        }
    }

    public interface AdvancedArithmetic
    {
        int divisorSum(int n);
    }
}
