using System;
using CodeHelpers;

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
        #region First Implementation

        private static void Equalization_1(int[] array)
        {
            if (IsEqual(array))
            {
                return;
            }

            SortArray(array);

            int nextIndex = GetNextIndex(array);
            int difference = array[nextIndex] - array[0];

            //calculate how many times 5 will be added
            int addTimes_5 = difference / 5;
            int remainsFrom_5 = difference % 5;
            if (addTimes_5 > 0)
            {
                EqualizeArray_1(array, nextIndex, 5, addTimes_5);
                m_Result += addTimes_5;
            }

            if (remainsFrom_5 == 0)
            {
                Equalization_1(array);
                return;
            }

            //calculate how many times 2 will be added
            int addTimes_2 = remainsFrom_5 / 2;
            int remainsFrom_2 = remainsFrom_5 % 2;
            if (addTimes_2 > 0)
            {
                EqualizeArray_1(array, nextIndex, 2, addTimes_2);
                m_Result += addTimes_2;
            }

            if (remainsFrom_2 == 0)
            {
                Equalization_1(array);
                return;
            }

            //calculate how many times 1 will be added
            EqualizeArray_1(array, nextIndex, 1, remainsFrom_2);
            m_Result += remainsFrom_2;
            Equalization_1(array);
        }

        private static void EqualizeArray_1(int[] array, int nextIndex, int addUnit, int addTimes)
        {
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

        #endregion

        //################################################################################
        #region Second Implementation

        private static void Equalization_2(int[] array)
        {
            if (IsEqual(array))
            {
                return;
            }

            SortArray(array);

            int additionCount = 0;
            int firstMaxIndex = array.Length - 1;
            int secondMaxIndex= GetSecondMaxIndex(array);

            //get difference between first and last element
            int difference = array[firstMaxIndex] - array[secondMaxIndex];

            if (difference > 2)
            {
                additionCount = difference / 3;
                if (additionCount == 0) additionCount++;

                EqualizeArray_2(array, firstMaxIndex, additionCount, 5);
            }

            if (difference == 2)
            {
                additionCount = difference / 2;
                if (additionCount == 0) additionCount++;

                EqualizeArray_2(array, firstMaxIndex, additionCount, 2);
            }

            if (difference < 2)
            {
                EqualizeArray_2(array, firstMaxIndex, difference, 1);
            }

            Equalization_2(array);
        }

        private static void EqualizeArray_2(int[] array, int maxIndex, int additionCount, int addition)
        {
            m_Result += additionCount;

            //add addition value to whole elements in the array, except max one
            for (int i = 0; i < array.Length; i++)
            {
                if (i != maxIndex)
                {
                    array[i] += additionCount * addition;
                }
            }
        }

        private static int GetMinIndex(int[] array)
        {
            int min = array[0];
            int index = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                    index = i;
                }
            }

            return index;
        }

        private static int GetSecondMaxIndex(int[] array)
        {
            int max = array[array.Length - 1];

            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] < max)
                {
                    return i;
                }
            }

            throw new Exception("Second max index cannot be found.");
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
