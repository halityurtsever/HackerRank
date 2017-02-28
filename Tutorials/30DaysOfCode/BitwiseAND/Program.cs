using CodeHelpers;
using System;

namespace HackerRank.Tutorials._30DaysOfCode.BitwiseAND
{
    public class Program
    {
        static void Main(string[] args)
        {
            IConsole console = new ConsoleWrapper();
            ExecuteTask(console);
        }

        public static void ExecuteTask(IConsole console)
        {
            int testCases = Convert.ToInt32(console.ReadLine());

            for (int i = 0; i < testCases; i++)
            {
                string[] tokens = console.ReadLine().Split(' ');
                int n = Convert.ToInt32(tokens[0]);
                int k = Convert.ToInt32(tokens[1]);

                int index = k;
                int result = 0;
                while (true)
                {
                    for (int j = index + 1; j <= n; j++)
                    {
                        if (((index & j) > result) && ((index & j) < k))
                        {
                            result = index & j;
                        }
                    }
                    if (result > 0 || index == 1)
                    {
                        break;
                    }
                    index--;
                }

                console.WriteLine(result);
            }
        }
    }
}
