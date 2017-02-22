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

            int additionCount = 0;
            int firstMaxIndex = array.Length - 1;
            int secondMaxIndex;
            int thirdMaxIndex;
            GetSecondMaxIndex(array, out secondMaxIndex, out thirdMaxIndex);

            //get difference between first and last element
            int difference = array[firstMaxIndex] - array[secondMaxIndex];

            if (difference > 2)
            {
                additionCount = 1;
                if (additionCount == 0) additionCount = difference / 3;
                if (additionCount != 0)
                    EqualizeArray_2(array, firstMaxIndex, additionCount, 5);
            }

            if (difference == 2)
            {
                additionCount = difference / 2;
                if (additionCount != 0)
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

        private static void GetSecondMaxIndex(int[] array, out int second, out int third)
        {
            int max = array[array.Length - 1];
            third = 0;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] < max)
                {
                    second = i;
                    third = i - 1;
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
