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

                SortArray(array);
                m_MinIndex = 0;
                m_MaxIndex = array.Length - 1;

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
                return;
            }

            bool isFinished = false;

            GetMaxCount(array);
            int minMaxDifference = array[m_MaxIndex] - array[m_MinIndex];

            //calculate how many times 5 will be added
            int addTimes_5 = minMaxDifference / 5;
            int remainsFrom_5 = minMaxDifference % 5;

            if (remainsFrom_5 > 2)
            {
                addTimes_5++;
                remainsFrom_5 = 0;
            }

            if (addTimes_5 > 0)
            {
                EqualizeArray(array, 5, addTimes_5);
            }

            if (remainsFrom_5 == 0)
            {
                isFinished = true;
            }

            //if nothing remains from 5 calculation
            if (!isFinished)
            {
                //calculate how many times 2 will be added
                int addTimes_2 = remainsFrom_5 / 2;
                int remainsFrom_2 = remainsFrom_5 % 2;

                if (addTimes_2 > 0)
                {
                    EqualizeArray(array, 2, addTimes_2);
                }

                if (remainsFrom_2 == 0)
                {
                    isFinished = true;
                }

                //if nothing remains from 2 calculation
                if (!isFinished)
                {
                    //calculate how many times 1 will be added
                    EqualizeArray(array, 1, remainsFrom_2);
                }
            }

            ShiftIndexes(array);
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

        private static void SetIndexes(int[] array)
        {
            //minIndex = GetMinIndex(array);
            //maxIndex = GetMaxIndex(array);
            //nextIndex = GetNextIndex(array, minIndex);
        }

        private static void ShiftIndexes(int[] array)
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
