using CodeHelpers;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace HackerRank.Tracks.Algorithms.DynamicProgramming.Equal
{
    public class Equal : ProblemBase, IProblemSolver
    {
        //################################################################################
        #region Fields

        private int m_Result;
        private int m_MinIndex;
        private int m_MaxIndex;

        private readonly StringBuilder m_Builder = new StringBuilder();

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

                SortArray(array, 0, arraySize - 1);
                m_MinIndex = 0;
                m_MaxIndex = array.Length - 1;

                try
                {
                    m_Builder.Clear();
                    m_Builder.AppendLine($"{"#",1}{"Unit",8}{"Count",8}{"Max",8}{"Result",8}");
                    m_Builder.AppendLine("---------------------------------");
                    Equalization(array);
                    m_Builder.AppendLine("---------------------------------");
                    m_Builder.Append($"{m_Result,33}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                File.WriteAllText("d:\\temp.txt", String.Empty);
                File.WriteAllText("d:\\temp.txt", m_Builder.ToString());
                Console.WriteLine(m_Result);
                m_Result = 0;
            }
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
            int addUnit, addCount;

            if (minMaxDifference > 4)
            {
                addUnit = 5;
                addCount = minMaxDifference / addUnit;

                m_Builder.AppendLine($"{"F",1}{addUnit,8}{addCount,8}{maxCount,8}{addCount * maxCount,8}");
            }
            else if (minMaxDifference > maxPreviousDifference)
            {
                addUnit = 2;
                addCount = minMaxDifference / addUnit;

                m_Builder.AppendLine($"{"S",1}{addUnit,8}{addCount,8}{maxCount,8}{addCount * maxCount,8}");
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
                var remain = minMaxDifference % addUnit;

                if (remain > 2)
                    addCount++;

                m_Builder.AppendLine($"{"T",1}{addUnit,8}{addCount,8}{maxCount,8}{addCount * maxCount,8}");
            }
            else
            {
                throw new Exception("Missing condition occurred.");
            }

            EqualizeArray(array, addUnit, addCount, maxCount);

            //Performance Improvement:
            //after equalize array shift min indexes to start of the array to make array sorted
            //so we do not need to call SortArray() method again.
            ShiftIndexesWithArrayCopy(array, maxCount);

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

            if (maxCount > 1) //performance improvement
            {
                for (int i = 0; i < maxCount; i++)
                {
                    array[firstMaxIndex + i] += addUnit * addCount * (maxCount - 1);
                }
            }

            m_Result += addCount * maxCount;
        }

        private void ShiftIndexesWithArrayCopy(int[] array, int maxCount)
        {
            var maxValue = array[array.Length - 1];
            var currentIndex = 0;
            while (true)
            {
                if (maxValue > array[currentIndex])
                {
                    currentIndex++;
                    continue;
                }
                break;
            }

            var destinationIndex = currentIndex + maxCount;
            Array.Copy(array, currentIndex, array, destinationIndex, array.Length - destinationIndex);

            for (int i = 0; i < maxCount; i++)
            {
                array[currentIndex + i] = maxValue;
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
