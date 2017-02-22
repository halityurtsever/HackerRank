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
        #region Second Implementation

        private static void Equalization_2(int[] array)
        {
            if (IsEqual(array))
            {
                return;
            }

            SortArray(array);

            int max = array.Length - 1;
            int min;
            int maxCount = GetMaxCount(array, out min);

            //get difference between first and last element
            int minMaxDifference = array[max] - array[min];

            if (minMaxDifference > 2)
            {
                
            }


            //if (difference > 2)
            //{
            //    additionCount = 1;
            //    if (additionCount == 0) additionCount = difference / 3;
            //    if (additionCount != 0)
            //        EqualizeArray_2(array, max, additionCount, 5);
            //}

            //if (difference == 2)
            //{
            //    additionCount = difference / 2;
            //    if (additionCount != 0)
            //        EqualizeArray_2(array, max, additionCount, 2);
            //}

            //if (difference < 2)
            //{
            //    EqualizeArray_2(array, max, difference, 1);
            //}

            //Equalization_2(array);
        }

        private static void EqualizeArray_2(int[] array, int maxIndex, int maxCount, int addition)
        {
            //add addition value to whole elements in the array, except max one
            for (int i = 0; i < array.Length; i++)
            {
                if (i != maxIndex)
                {
                    array[i] += addition;
                }
            }
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
