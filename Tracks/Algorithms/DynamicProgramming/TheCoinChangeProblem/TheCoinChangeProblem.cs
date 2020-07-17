using CodeHelpers;
using System;

namespace HackerRank.Tracks.Algorithms.DynamicProgramming.TheCoinChangeProblem
{
    public class TheCoinChangeProblem : ProblemBase, IProblemSolver
    {
        //################################################################################
        #region Fields

        private int m_StartIndex;
        private int m_CurrentIndex;
        private int m_TargetChangeValue;
        private int[] m_CoinArray;

        #endregion

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
            var initialValues = Console.ReadLine().Split(' ');
            m_TargetChangeValue = Convert.ToInt32(initialValues[0]);
            m_CoinArray = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);

            SortArray(m_CoinArray, 0, m_CoinArray.Length - 1);

            m_StartIndex = m_CoinArray.Length - 1;
            m_CurrentIndex = m_CoinArray.Length;
            CalculateDistinctChanges(0);
        }

        private void CalculateDistinctChanges(int total)
        {
            while (m_StartIndex >= 0)
            {
                int currentTotal = m_CoinArray[m_CurrentIndex] + total;
                if (currentTotal > m_TargetChangeValue)
                {
                    m_CurrentIndex--;
                    return;
                }


                CalculateDistinctChanges(currentTotal);
            }
        }

        private void SortArray(int[] array, int low, int hi)
        {
            //Quick Sort
            if (low < hi)
            {
                int p = Partition(array, low, hi);
                SortArray(array, low, p - 1);
                SortArray(array, p + 1, hi);
            }
        }

        private int Partition(int[] array, int low, int hi)
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
