using CodeHelpers;
using System;
using System.Collections.Generic;

namespace HackerRank.Tracks.Algorithms.DynamicProgramming.TheCoinChangeProblem
{
    class Program_TheCoinChangeProblem
    {
        //################################################################################
        #region Fields

        private static HashSet<string> m_DistinctCoinChanges = new HashSet<string>();

        #endregion

        //################################################################################
        #region Public Implementation

        public static void Main(string[] args)
        {
            IConsole console = new ConsoleWrapper();
            ExecuteTask(console);
        }

        public static void ExecuteTask(IConsole console)
        {
            //read values from console
            var initialValues = console.ReadLine().Split(' ');
            int coinChangeValue = Convert.ToInt32(initialValues[0]);
            int coinArraySize = Convert.ToInt32(initialValues[1]);
            int[] coinArray = Array.ConvertAll(console.ReadLine().Split(' '), Int32.Parse);
        }

        #endregion

        //################################################################################
        #region Private Implementation



        #endregion
    }
}
