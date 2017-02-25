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
        private static int m_NextIndex;

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

                SetIndexes(array);
                Equalization(array);

                console.WriteLine(m_Result);
                m_Result = 0;
            }
        }

        #endregion

        //################################################################################
        #region Second Implementation

        private static void Equalization(int[] array)
        {
            if (IsEqual(array))
            {
                //TraceArray(array);
                return;
            }

            //SortArray(array);
            //TraceArray(array);

            //int minIndex = 0;
            //int maxIndex = array.Length - 1;
            CheckIndexes(array);
            m_MaxIndex = GetMaxIndex(array);
            int minMaxDifference = array[m_MaxIndex] - array[m_MinIndex];
            int minNextDifference = array[m_NextIndex] - array[0];

            //calculate how many times 5 will be added
            int addTimes_5 = minMaxDifference / 5;
            int remainsFrom_5 = minMaxDifference % 5;

            if (remainsFrom_5 > 2 && minNextDifference > 1)
            {
                addTimes_5++;
            }

            if (addTimes_5 > 0)
            {
                EqualizeArray(array, m_MaxIndex, 5, addTimes_5);
                m_Result += addTimes_5;
                remainsFrom_5 = 0;
            }

            if (remainsFrom_5 == 0)
            {
                Equalization(array);
                return;
            }

            //calculate how many times 2 will be added
            int addTimes_2 = remainsFrom_5 / 2;
            int remainsFrom_2 = remainsFrom_5 % 2;

            if (addTimes_2 > 0)
            {
                EqualizeArray(array, m_MaxIndex, 2, addTimes_2);
                m_Result += addTimes_2;
            }

            if (remainsFrom_2 == 0)
            {
                Equalization(array);
                return;
            }

            //calculate how many times 1 will be added
            EqualizeArray(array, m_MaxIndex, 1, remainsFrom_2);
            m_Result += remainsFrom_2;
            Equalization(array);
        }

        private static void EqualizeArray(int[] array, int nextIndex, int addUnit, int addTimes)
        {
            //Debug.WriteLine($"AddUnit: {addUnit}, AddTimes: {addTimes}, Result: {m_Result}");
            for (int i = 0; i < array.Length; i++)
            {
                if (i != nextIndex)
                {
                    array[i] += addUnit * addTimes;
                }
            }
        }

        private static void SetIndexes(int[] array)
        {
            m_MinIndex = GetMinIndex(array);
            m_MaxIndex = GetMaxIndex(array);
            m_NextIndex = GetNextIndex(array, m_MinIndex);
        }

        private static void CheckIndexes(int[] array)
        {
            if (array[m_MaxIndex] < array[m_MinIndex])
            {
                m_MinIndex = m_MaxIndex;
            }
            else if (array[m_MaxIndex] < array[m_NextIndex])
            {
                m_NextIndex = m_MaxIndex;
            }
        }

        private static int GetMinIndex(int[] array)
        {
            int min = array[0];
            int minIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }

        private static int GetMaxIndex(int[] array)
        {
            int max = array[0];
            int maxIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

        private static int GetNextIndex(int[] array, int minIndex)
        {
            int min = array[minIndex];
            int nextIndex = minIndex == 0 ? 1 : 0;
            int next = array[nextIndex];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > min && array[i] < next)
                {
                    next = array[i];
                    nextIndex = i;
                }
            }

            return nextIndex;
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
            //Insertion sort
            for (int i = 1; i < array.Length; i++)
            {
                var index = i;
                while (index > 0)
                {
                    if (array[index] < array[index - 1])
                    {
                        var temp = array[index - 1];
                        array[index - 1] = array[index];
                        array[index] = temp;
                    }
                    index--;

                }
            }
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

        #endregion
    }
}
