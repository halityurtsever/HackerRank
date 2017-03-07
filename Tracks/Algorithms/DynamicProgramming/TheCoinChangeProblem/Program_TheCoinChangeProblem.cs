using CodeHelpers;
using System;

namespace HackerRank.Tracks.Algorithms.DynamicProgramming.TheCoinChangeProblem
{
    class Program_TheCoinChangeProblem
    {
        //################################################################################
        #region Fields


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
            int targetChangeValue = Convert.ToInt32(initialValues[0]);
            int coinArraySize = Convert.ToInt32(initialValues[1]);
            int[] coinArray = Array.ConvertAll(console.ReadLine().Split(' '), Int32.Parse);

            SortArray(coinArray, 0, coinArray.Length - 1);

            BuildCoinTree(coinArray, targetChangeValue);
            CalculateDistinctChanges(targetChangeValue);
        }

        #endregion

        //################################################################################
        #region Private Implementation

        private static void BuildCoinTree(int[] array, int targetValue)
        {

        }

        private static void CalculateDistinctChanges(int targetValue)
        {
            
        }

        private static void SortArray(int[] array, int low, int hi)
        {
            //Quick Sort
            if (low < hi)
            {
                int p = Partition(array, low, hi);
                SortArray(array, low, p - 1);
                SortArray(array, p + 1, hi);
            }
        }

        private static int Partition(int[] array, int low, int hi)
        {
            int pivot = array[hi];
            int i = low - 1;
            int temp;

            for (int j = low; j <= hi - 1; j++)
            {
                if (array[j] <= pivot)
                {
                    i = i + 1;
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
            temp = array[i + 1];
            array[i + 1] = array[hi];
            array[hi] = temp;

            return i + 1;
        }

        #endregion
    }
}
