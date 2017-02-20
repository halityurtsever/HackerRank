using CodeHelpers;
using System;

namespace HackerRank.Tracks.DataStructures.Arrays.AlgorithmicCrush
{
    public class Program_AlgorithmicCrush
    {
        //################################################################################
        #region Fields

        static void Main()
        {
            IConsole console = new ConsoleWrapper();

            var initialsString = console.ReadLine();
            var initialsArray = initialsString.Split(' ');
            var arraySize = Convert.ToInt32(initialsArray[0]);
            var querySize = Convert.ToInt32(initialsArray[1]);

            Execute(console, querySize, arraySize);
        }

        #endregion

        //################################################################################
        #region Public Implementation

        public static void Execute(IConsole console, int querySize, int arraySize)
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

        //################################################################################
        #region Temp Implementation

        //public static long Execute(IConsole console, int querySize, int arraySize)
        //{
        //    var queryArray = new string[3];
        //    var startIndex = 0;
        //    var endIndex = 0;
        //    var incrementValue = 0;

        //    //initiate array
        //    long[] array = new long[arraySize];

        //    for (int i = 0; i < querySize; i++)
        //    {
        //        queryArray = console.Readline().Split(' ');

        //        startIndex = Convert.ToInt32(queryArray[0]) - 1;
        //        endIndex = Convert.ToInt32(queryArray[1]) - 1;
        //        incrementValue = Convert.ToInt32(queryArray[2]);

        //        for (int j = startIndex; j <= endIndex; j++)
        //        {
        //            array[j] += incrementValue;
        //        }
        //    }

        //    //print the highest value
        //    long maxValue = 0;
        //    for (int i = 0; i < arraySize; i++)
        //    {
        //        if (array[i] > maxValue)
        //            maxValue = array[i];
        //    }

        //    return maxValue;
        //}

        #endregion
    }
}
