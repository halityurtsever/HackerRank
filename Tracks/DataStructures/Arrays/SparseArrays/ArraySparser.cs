using System;

using CodeHelpers;

namespace SparseArrays.Library
{
    public class ArraySparser : ProblemSolverBase, IProblemSolver
    {
        //################################################################################
        #region IProblemSolver Members

        void IProblemSolver.Solve(IConsole console)
        {
            Console = console;
            SolveProblem();
        }

        #endregion

        //################################################################################
        #region Private Members

        private void SolveProblem()
        {
            //read input count and input values
            int inputCount = Convert.ToInt32(Console.ReadLine());
            string[] inputs = new string[inputCount];

            for (int i = 0; i < inputCount; i++)
            {
                inputs[i] = Console.ReadLine();
            }

            //read query count and query values
            int queryCount = Convert.ToInt32(Console.ReadLine());
            string[] queries = new string[queryCount];

            for (int i = 0; i < queryCount; i++)
            {
                queries[i] = Console.ReadLine();
            }

            //find matches
            for (int i = 0; i < queryCount; i++)
            {
                var matchCount = 0;
                for (int j = 0; j < inputCount; j++)
                {
                    if (inputs[j] == queries[i])
                    {
                        matchCount++;
                    }
                }
                Console.WriteLine(matchCount);
            }
        }

        #endregion
    }
}
