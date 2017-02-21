using System;

namespace Equal
{
    public class Program
    {
        private static int m_Result = 0;

        static void Main(string[] args)
        {
            int testCases = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < testCases; i++)
            {
                int arraySize = Convert.ToInt32(Console.ReadLine());
                string[] arrayData = Console.ReadLine().Split(' ');
                int[] array = new[] { 62, 12, 8, 24, 89, 12, 47 };//Array.ConvertAll(arrayData, Int32.Parse);

                SortArray(array);
                Equalization(array);

                Console.WriteLine(m_Result);
            }
        }

        private static void Equalization(int[] array)
        {
            if (IsEqual(array))
            {
                return;
            }

            int nextIndex = GetNextIndex(array);
            int difference = array[nextIndex] - array[0];

            //calculate how many times 5 will be added
            int addTimes_5 = difference / 5;
            int remainsFrom_5 = difference % 5;
            if (addTimes_5 > 0)
            {
                EqualizeArray(array, nextIndex, 5, addTimes_5);
                m_Result += addTimes_5;
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
                //TODO: continue from here.
            }
            EqualizeArray(array, nextIndex, 2, addTimes_2);

            EqualizeArray(array, nextIndex, 1, remainsFrom_2);

            m_Result += addTimes_5 + addTimes_2 + remainsFrom_2;
        }

        private static void EqualizeArray(int[] array, int nextIndex, int addUnit, int addTimes)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i != nextIndex)
                {
                    array[i] += addUnit * addTimes;
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

        private static int GetNextIndex(int[] array)
        {
            int min = array[0];
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > min)
                {
                    return i;
                }
            }

            throw new Exception("Next index cannot be found.");
        }

        private static int GetMinCount(int[] array, int min)
        {
            int count = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == min)
                {
                    count++;
                }
            }

            return count;
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
    }
}
