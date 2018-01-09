using CodeHelpers;
using System;

namespace HackerRank.Tutorials._30DaysOfCode.BitwiseAND
{
    public class BitwiseAND : ProblemBase, IProblemSolver
    {
        //################################################################################
        #region IProblemSolver Implementation

        void IProblemSolver.Execute(IConsole console)
        {
            Console = console;
            SolveProblem();
        }

        #endregion

        //################################################################################
        #region ProblemBase Overrides

        protected override void ReadInputs()
        {
            Inputs.Add("testCases", Convert.ToInt32(Console.ReadLine()));
        }

        protected override void SolveProblem()
        {
            ReadInputs();
            int testCases = (int) Inputs["testCases"];

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
