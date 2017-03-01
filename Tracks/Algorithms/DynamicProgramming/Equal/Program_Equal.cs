using CodeHelpers;
using System;
using System.Diagnostics;

namespace HackerRank.Tracks.Algorithms.DynamicProgramming.Equal
{
    public class Program_Equal
    {
        //################################################################################
        #region Fields

        private static int m_Result = 0;
        private static int m_MinIndex;
        private static int m_MaxIndex;
        private static int m_MaxCount;

        #endregion

        //################################################################################
        #region Public Implementation

        public static void Main()
        {
            var console = new ConsoleWrapper();
            ExecuteTask(console);
        }

        public static void ExecuteTask(IConsole console)
        {
            int testCases = Convert.ToInt32(console.ReadLine());

            for (int i = 0; i < testCases; i++)
            {
                int arraySize = Convert.ToInt32(console.ReadLine());
                string[] arrayData = console.ReadLine().Split(' ');
                int[] array = Array.ConvertAll(arrayData, Int32.Parse);

                SortArray(array, 0, array.Length - 1);
                m_MinIndex = 0;
                m_MaxIndex = array.Length - 1;

                Equalization(array);

                console.WriteLine(m_Result);
                m_Result = 0;
            }
        }

        #endregion

        //################################################################################
        #region Private Implementation

        private static void Equalization(int[] array)
        {
            if (IsEqual(array))
            {
                return;
            }

            bool isContinue = true;

            //count of max numbers in the array
            GetMaxCount(array);

            //difference between min number and max number
            int minMaxDifference = array[m_MaxIndex] - array[m_MinIndex];

            //difference between max number and previous max number
            int maxPreviousDifference = array[m_MaxIndex] - array[m_MaxIndex - m_MaxCount];

            //calculate how many times 5 will be added
            int addTimes_5 = maxPreviousDifference / 5;
            int remainsFrom_5 = maxPreviousDifference % 5;

            //continue to add 5 till difference between min and max less than 5
            if (remainsFrom_5 > 2 || (minMaxDifference > 4 && minMaxDifference > maxPreviousDifference))
            {
                addTimes_5++;
                isContinue = false;
            }

            if (addTimes_5 > 0)
            {
                EqualizeArray(array, 5, addTimes_5);
            }

            if (remainsFrom_5 == 0)
            {
                isContinue = false;
            }

            //if nothing remains from 5 calculation
            if (isContinue)
            {
                //calculate how many times 2 will be added
                int addTimes_2 = remainsFrom_5 / 2;
                int remainsFrom_2 = remainsFrom_5 % 2;

                if (addTimes_2 == 0 && minMaxDifference > 1)
                {
                    addTimes_2++;
                    isContinue = false;
                }

                if (addTimes_2 > 0)
                {
                    EqualizeArray(array, 2, addTimes_2);
                }

                //if nothing remains from 2 calculation
                if (isContinue)
                {
                    //calculate how many times 1 will be added
                    EqualizeArray(array, 1, remainsFrom_2);
                }
            }

            //Performance Improvement:
            //after equalize array shift min indexes to start of the array to make array sorted
            //so we do not need to call SortArray() method again.
            ShiftIndexes(ref array);

            Equalization(array);
        }

        private static void EqualizeArray(int[] array, int addUnit, int addTimes)
        {
            int firstMaxIndex = array.Length - m_MaxCount;

            //add all numbers that less than max
            for (int i = 0; i < array.Length - m_MaxCount; i++)
            {
                array[i] += addUnit * addTimes * m_MaxCount;
            }

            for (int i = 0; i < m_MaxCount; i++)
            {
                array[firstMaxIndex + i] += addUnit * addTimes * (m_MaxCount - 1);
            }

            m_Result += addTimes * m_MaxCount;
        }

        private static void ShiftIndexes(ref int[] array)
        {
            int firstMaxIndex = array.Length - m_MaxCount;
            int tempMaxCount = m_MaxCount;
            int[] tempArray = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                if (tempMaxCount > 0)
                {
                    if (array[i] >= array[firstMaxIndex])
                    {
                        tempArray[i] = array[firstMaxIndex];
                        firstMaxIndex++;
                        tempMaxCount--;
                        continue;
                    }
                    tempArray[i] = array[i];
                    continue;
                }
                tempArray[i] = array[i - m_MaxCount];
            }

            array = tempArray;
        }

        private static void GetMaxCount(int[] array)
        {
            m_MaxCount = 1;
            for (int i = array.Length - 2; i >= 0; i--)
            {
                if (array[i] == array[m_MaxIndex])
                {
                    m_MaxCount++;
                }
                else
                {
                    break;
                }
            }
        }

        private static bool IsEqual(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] != array[i + 1])
                {
                    return false;
                }
            }

            return true;
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

        //################################################################################
        #region Helper Implementation

        private static void TraceArray(int[] array)
        {
            string list = string.Empty;
            for (int i = 0; i < array.Length; i++)
            {
                list += $"{array[i]} - ";
            }
            Debug.Write($"({m_Result}): {list}");
            Debug.WriteLine("");
        }

        #endregion
    }
}
