using CodeHelpers;

using System;

namespace AlgorithmicCrush.Library
{
    public class AlgorithmicCrusher : ProblemSolverBase, IProblemSolver
    {
        //################################################################################
        #region IProblemSolver Members

        void IProblemSolver.Solve(IConsole console)
        {
            Console = console;

            var initialsString = console.ReadLine();
            var initialsArray = initialsString.Split(' ');
            var arraySize = Convert.ToInt32(initialsArray[0]);
            var querySize = Convert.ToInt32(initialsArray[1]);

            Execute(arraySize, querySize);
        }

        #endregion

        //################################################################################
        #region Private Members

        private void Execute(int arraySize, int querySize)
        {
            string[] queryArray;
            long aux = 0;
            long maxValue = 0;

            long[] a1 = new long[arraySize + 1];
            long[] a2 = new long[arraySize + 1];

            for (int i = 0; i < querySize; i++)
            {
                queryArray = Console.ReadLine().Split(' ');
                int startElement = Convert.ToInt32(queryArray[0]);
                int endElement = Convert.ToInt32(queryArray[1]);
                long increment = Convert.ToInt32(queryArray[2]);

                a1[startElement - 1] += increment;
                a1[endElement] -= increment;
            }

            for (int j = 0; j < arraySize; j++)
            {
                aux += a1[j];
                a2[j] += aux;

                maxValue = Math.Max(a2[j], maxValue);
            }

            Console.WriteLine(maxValue);
        }

        #endregion
    }
}
