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

                try
                {
                    Equalization(array);
                } 
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }

                console.WriteLine(m_Result);
                m_Result = 0;
            }
        }

        #endregion

        //################################################################################
        #region Private Implementation

        private static void Equalization(int[] array)
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

            if (minMaxDifference == maxPreviousDifference)
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
            else if (minMaxDifference > 4)
            {
                //add 5 till difference between min and max greater than 4
                addUnit = 5;
                addCount = minMaxDifference / addUnit;
                remain = minMaxDifference % addUnit;
            }
            else if (minMaxDifference > maxPreviousDifference)
            {
                if (minMaxDifference >= 2)
                    addUnit = 2;
                else
                    addUnit = 1;

                addCount = minMaxDifference / addUnit;
                remain = minMaxDifference % addUnit;
            }
            else
            {
                throw new Exception("Missing condition occured.");
            }

            EqualizeArray(array, addUnit, addCount, maxCount);

            //Performance Improvement:
            //after equalize array shift min indexes to start of the array to make array sorted
            //so we do not need to call SortArray() method again.
            ShiftIndexes(ref array, maxCount);

            Equalization(array);
        }

        private static void EqualizeArray(int[] array, int addUnit, int addCount, int maxCount)
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

        private static void ShiftIndexes(ref int[] array, int maxCount)
        {
            int firstMaxIndex = array.Length - maxCount;
            int tempMaxCount = maxCount;
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
                tempArray[i] = array[i - maxCount];
            }

            array = tempArray;
        }

        private static int GetMaxCount(int[] array)
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

        private static bool IsEqual(int[] array)
        {
            return array[m_MinIndex] == array[m_MaxIndex];
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

        private static void TraceArray(int[] array, bool isReorder)
        {
            string list = string.Empty;
            for (int i = 0; i < array.Length; i++)
            {
                list += $"{array[i]} - ";
            }
            string header = $"(TOTAL: {m_Result.ToString().PadLeft(3, '0')}):\t";
            if (isReorder)
            {
                header = "REORDERED:\t\t";
            }
            Debug.Write($"{header}{list.Substring(0, list.Length - 3)}");
            Debug.WriteLine("");
        }

        #endregion
    }
}
