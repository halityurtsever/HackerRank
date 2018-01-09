using CodeHelpers;
using System;

namespace HackerRank.Tracks.DataStructures.Arrays.AlgorithmicCrush
{
    public class AlgorithmicCrush : ProblemBase, IProblemSolver
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
        #region Private Implementation

        private void SolveProblem()
        {
            var initialsString = Console.ReadLine().Split(' ');

            int arraySize = Convert.ToInt32(initialsString[0]);
            int querySize = Convert.ToInt32(initialsString[1]);
            long aux = 0;
            long maxValue = 0;

            long[] a1 = new long[arraySize + 1];
            long[] a2 = new long[arraySize + 1];

            for (int i = 0; i < querySize; i++)
            {
                var queryArray = Console.ReadLine().Split(' ');
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
