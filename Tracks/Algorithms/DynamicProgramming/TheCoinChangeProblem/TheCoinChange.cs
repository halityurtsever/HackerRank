using CodeHelpers;

using System;
using System.Collections.Generic;

namespace TheCoinChangeProblem.Library
{
    public class TheCoinChange : ProblemSolverBase, IProblemSolver
    {
        //################################################################################
        #region Fields

        private int targetValue;
        private int[] coinArray;
        private IDictionary<int, IList<string>> patternLibrary;
        private HashSet<int> resultSet;

        #endregion

        //################################################################################
        #region IProblemSolver Members

        void IProblemSolver.Solve(IConsole console)
        {
            patternLibrary = new Dictionary<int, IList<string>>();
            resultSet = new HashSet<int>();

            Console = console;
            SolveProblem();

            Console.WriteLine(resultSet.Count);
        }

        #endregion

        //################################################################################
        #region Private Members

        private void SolveProblem()
        {
            var initialValues = Console.ReadLine().Split(' ');
            targetValue = int.Parse(initialValues[0]);
            coinArray = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            SortArray(coinArray, 0, coinArray.Length - 1, coinArray.Length);
            CreatePatternLibrary();
            CalculateDistinctChanges();
        }

        private void CalculateDistinctChanges()
        {

        }

        // 12 - 10 - 7 - 3 - 1

        //12
        //10,1,1
        //7,3,1,1
        //7,1,1,1,1,1
        //3,3,3,3
        //3,3,3,1,1,1
        //3,3,1,1,1,1,1,1
        //3,1,1,1,1,1,1,1,1,1
        //1,1,1,1,1,1,1,1,1,1,1,1

        //10
        //7,3
        //7,1,1,1
        //3,3,3,1
        //3,3,1,1,1,1
        //3,1,1,1,1,1,1,1
        //1,1,1,1,1,1,1,1,1,1

        //7
        //3,3,1
        //3,1,1,1,1
        //1,1,1,1,1,1,1

        //3
        //1,1,1

        //1

        private void CreatePatternLibrary()
        {
            foreach (var number in coinArray)
            {
                var patternList = GetPatternList(number);
                patternLibrary.Add(number, patternList);
            }
        }

        private IList<string> GetPatternList(int number)
        {
            var patternList = new List<string>();
            var coinEnumerator = coinArray.GetEnumerator();

            while (coinEnumerator.MoveNext())
            {
                
            }

            return patternList;
        }

        /// <summary>
        /// Descending quick sort algorithm
        /// </summary>
        /// <param name="data">Array will be sorted</param>
        /// <param name="left">Start index</param>
        /// <param name="right">End index</param>
        /// <param name="count">Array length</param>
        private void SortArray(int[] data, int left, int right, int count)
        {
            int i, j, temp;
            double pivot;

            i = left;
            j = right;
            pivot = data[(left + right) / 2];

            do
            {
                while ((data[i] > pivot) && (i < right)) i++;
                count++;

                while ((pivot > data[j]) && (j > left)) j--;
                count++;

                if (i <= j)
                {
                    temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                    i++;
                    j--;
                    count++;
                }
            } while (i <= j);

            if (left < j) SortArray(data, left, j, count);
            if (i < right) SortArray(data, i, right, count);
        }

        #endregion
    }
}
