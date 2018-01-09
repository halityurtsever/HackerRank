using CodeHelpers;
using System;
using System.Diagnostics;

namespace HackerRank.Tracks.Algorithms.DynamicProgramming.Equal
{
    public class Equal : ProblemBase, IProblemSolver
    {
        //################################################################################
        #region Fields

        private static int m_Result;
        private static int m_MinIndex;
        private static int m_MaxIndex;

        private static readonly Stopwatch m_SwEqualize = new Stopwatch();
        private static readonly Stopwatch m_SwShift = new Stopwatch();

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
            int testCases = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < testCases; i++)
            {
                int arraySize = Convert.ToInt32(Console.ReadLine());
                string[] arrayData = Console.ReadLine().Split(' ');
                int[] array = Array.ConvertAll(arrayData, Int32.Parse);

                //TraceArray(array, "INIT");
                SortArray(array, 0, arraySize - 1);
                //TraceArray(array, "SORT");
                m_MinIndex = 0;
                m_MaxIndex = array.Length - 1;

                try
                {
                    Equalization(array);
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }

                Console.WriteLine(m_Result);
                m_Result = 0;
            }

            //Debug.WriteLine("------------------------------------");
            //Debug.WriteLine($"Equalize Elapsed: {m_SwEqualize.ElapsedMilliseconds}");
            //Debug.WriteLine($"Shift Elapsed: {m_SwShift.ElapsedMilliseconds}");
            //m_SwShift.Reset();
            //m_SwEqualize.Reset();
        }

        private void Equalization(int[] array)
        {
            //finish, no more equalization
            if (IsEqual(array)) return;

            //count of max numbers in the array
            int maxCount = GetMaxCount(array);

            //difference between min number and max number
            int minMaxDifference = array[m_MaxIndex] - array[m_MinIndex];

            //difference between max number and previous max number
            int maxPreviousDifference = array[m_MaxIndex] - array[m_MaxIndex - maxCount];

            //calculate addition count
            int addUnit, addCount, remain;

            if (minMaxDifference > 4)
            {
                addUnit = 5;
                addCount = minMaxDifference / addUnit;
            }
            else if (minMaxDifference == maxPreviousDifference)
            {
                if (minMaxDifference > 2)
                    addUnit = 5;
                else if (minMaxDifference == 2)
                    addUnit = 2;
                else
                    addUnit = 1;

                addCount = minMaxDifference / addUnit;
                remain = minMaxDifference % addUnit;

                if (remain > 2)
                    addCount++;
            }
            else if (minMaxDifference > maxPreviousDifference)
            {
                if (minMaxDifference >= 2)
                    addUnit = 2;
                else
                    addUnit = 1;

                addCount = minMaxDifference / addUnit;
            }
            else
            {
                throw new Exception("Missing condition occured.");
            }

            m_SwEqualize.Start();
            EqualizeArray(array, addUnit, addCount, maxCount);
            //TraceArray(array, "EQUAL");
            m_SwEqualize.Stop();

            m_SwShift.Start();
            //Performance Improvement:
            //after equalize array shift min indexes to start of the array to make array sorted
            //so we do not need to call SortArray() method again.
            ShiftIndexes(ref array, maxCount);
            //TraceArray(array, "SHIFT");
            m_SwShift.Stop();
            Equalization(array);
        }

        private void EqualizeArray(int[] array, int addUnit, int addCount, int maxCount)
        {
            int firstMaxIndex = array.Length - maxCount;

            //add all numbers that less than max
            for (int i = 0; i < array.Length - maxCount; i++)
            {
                array[i] += addUnit * addCount * maxCount;
            }

            for (int i = 0; i < maxCount; i++)
            {
                array[firstMaxIndex + i] += addUnit * addCount * (maxCount - 1);
            }

            m_Result += addCount * maxCount;
        }

        private void ShiftIndexes(ref int[] array, int maxCount)
        {
            int firstMaxIndex = array.Length - maxCount;
            int previousMaxIndex = firstMaxIndex - 1;
            int oldMaxValue = array[firstMaxIndex];
            int currentIndex = array.Length - 1;

            while (true)
            {
                if (previousMaxIndex >= 0 && array[previousMaxIndex] > oldMaxValue)
                {
                    array[currentIndex] = array[previousMaxIndex];
                    array[previousMaxIndex] = oldMaxValue;
                    currentIndex--;
                    previousMaxIndex--;
                }
                else
                {
                    break;
                }
            }
        }

        private int GetMaxCount(int[] array)
        {
            int maxCount = 1;
            for (int i = array.Length - 2; i >= 0; i--)
            {
                if (array[i] == array[m_MaxIndex])
                {
                    maxCount++;
                }
                else
                {
                    break;
                }
            }

            return maxCount;
        }

        private bool IsEqual(int[] array)
        {
            return array[m_MinIndex] == array[m_MaxIndex];
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

        //################################################################################
        #region Helper Implementation

        private void TraceArray(int[] array, string stage)
        {
            string list = string.Empty;
            for (int i = 0; i < array.Length; i++)
            {
                list += $"{array[i]} - ";
            }
            Debug.Write($"{stage}: {list.Substring(0, list.Length - 3)}");
            Debug.WriteLine("");
        }

        private void IsArraySorted(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    Console.WriteLine("not sorted");
                }
            }
        }

        #endregion
    }
}
