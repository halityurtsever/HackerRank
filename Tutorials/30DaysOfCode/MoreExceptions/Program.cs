using System;

namespace HackerRank.Tutorials._30DaysOfCode.MoreExceptions
{
    class Program
    {
        static void Main(String[] args)
        {
            Calculator myCalculator = new Calculator();
            int T = Int32.Parse(Console.ReadLine());
            while (T-- > 0)
            {
                string[] num = Console.ReadLine().Split();
                int n = int.Parse(num[0]);
                int p = int.Parse(num[1]);
                try
                {
                    int ans = myCalculator.power(n, p);
                    Console.WriteLine(ans);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
            }



        }
    }

    internal class Calculator
    {
        public int power(int i, int i1)
        {
            if (i < 0 || i1 < 0)
            {
                throw new Exception("n and p should be non-negative");
            }

            return Convert.ToInt32(Math.Pow(i, i1));
        }
    }
}
