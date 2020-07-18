using CodeHelpers;

using System;

namespace HackerRank.Tutorials._30DaysOfCode.BitwiseAND
{
    public class BitwiseAND : ProblemSolverBase, IProblemSolver
    {
        //################################################################################
        #region IProblemSolver Implementation

        void IProblemSolver.Solve(IConsole console)
        {
            Console = console;

            int testCases = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < testCases; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ');
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
                    if (index == 1)
                    {
                        break;
                    }
                    index--;
                }

                Console.WriteLine(result);
            }
        }

        #endregion
    }
}
