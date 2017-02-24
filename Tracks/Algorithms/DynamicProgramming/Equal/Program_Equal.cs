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

                //Equalization_1(array);
                Equalization_2(array);

                console.WriteLine(m_Result);
                m_Result = 0;
            }
        }

        #endregion

        //################################################################################
        #region Second Implementation

        private static void Equalization_2(int[] array)
        {
            if (IsEqual(array))
            {
                //TraceArray(array);
                return;
            }

            SortArray(array);
            //TraceArray(array);

            int maxIndex = array.Length - 1;
            int nextIndex = GetNextIndex(array);
            int minMaxDifference = array[maxIndex] - array[0];
            int minNextDifference = array[nextIndex] - array[0];

            //calculate how many times 5 will be added
            int addTimes_5 = minMaxDifference / 5;
            int remainsFrom_5 = minMaxDifference % 5;

            //if (remainsFrom_5 > 2 && minNextDifference > 2)
            //{
            //    addTimes_5++;
            //    remainsFrom_5 = 0;
            //}

            if (addTimes_5 > 0)
            {
                EqualizeArray_2(array, maxIndex, 5, addTimes_5);
                m_Result += addTimes_5;
                remainsFrom_5 = 0;
            }

            if (remainsFrom_5 == 0)
            {
                Equalization_2(array);
                return;
            }

            //calculate how many times 2 will be added
            int addTimes_2 = remainsFrom_5 / 2;
            int remainsFrom_2 = remainsFrom_5 % 2;
            if (addTimes_2 > 0)
            {
                EqualizeArray_2(array, maxIndex, 2, addTimes_2);
                m_Result += addTimes_2;
            }

            if (remainsFrom_2 == 0)
            {
                Equalization_2(array);
                return;
            }

            //calculate how many times 1 will be added
            EqualizeArray_2(array, maxIndex, 1, remainsFrom_2);
            m_Result += remainsFrom_2;
            Equalization_2(array);
        }

        private static void EqualizeArray_2(int[] array, int nextIndex, int addUnit, int addTimes)
        {
            Debug.WriteLine($"AddUnit: {addUnit}, AddTimes: {addTimes}, Result: {m_Result}");
            for (int i = 0; i < array.Length; i++)
            {
                if (i != nextIndex)
                {
                    array[i] += addUnit * addTimes;
                }
            }
        }

        private static int GetNextIndex(int[] array)
        {
            int min = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > min)
                {
                    return i;
                }
            }

            throw new Exception("Next index cannot be found.");
        }

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

        private static int GetMaxCount(int[] array, out int min)
        {
            int max = array.Length - 1;
            int maxCount = 1;
            min = -1;

            for (int i = array.Length - 2; i >= 0; i--)
            {
                //if min is set, break loop
                if (min != -1)
                    break;

                //if next number is equal to max, increase max
                if (array[i] == array[max])
                {
                    maxCount++;
                    continue;
                }

                //if next number is less than max and min is not set
                //set min number
                if (array[i] < array[max] && min == -1)
                {
                    min = i;
                }
            }

            return maxCount;
        }

        #endregion

        //################################################################################
        #region Private Implementation

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

        private static void SortArray(int[] array)
        {
            //Bubble sort array
            bool isSwapped = true;
            while (isSwapped)
            {
                isSwapped = false;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        isSwapped = true;
                    }
                }
            }
        }

        #endregion
    }
}
