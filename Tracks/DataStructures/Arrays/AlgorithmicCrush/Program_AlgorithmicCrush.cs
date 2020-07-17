using CodeHelpers;
using System;

namespace HackerRank.Tracks.DataStructures.Arrays.AlgorithmicCrush
{
    public class Program_AlgorithmicCrush
    {
        static void Main()
        {
            IConsole console = new ConsoleWrapper();

            var initialsString = console.ReadLine();
            var initialsArray = initialsString.Split(' ');
            var arraySize = Convert.ToInt32(initialsArray[0]);
            var querySize = Convert.ToInt32(initialsArray[1]);

            ExecuteTask(console, arraySize, querySize);
        }

        //################################################################################
        #region Public Implementation

        public static void ExecuteTask(IConsole console, int arraySize, int querySize)
        {
            string[] queryArray;
            long aux = 0;
            long maxValue = 0;

            long[] a1 = new long[arraySize + 1];
            long[] a2 = new long[arraySize + 1];

            for (int i = 0; i < querySize; i++)
            {
                queryArray = console.ReadLine().Split(' ');
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

            console.WriteLine(maxValue);
        }

        #endregion
    }
}
