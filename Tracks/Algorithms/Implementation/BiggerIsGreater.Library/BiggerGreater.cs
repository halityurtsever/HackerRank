using CodeHelpers;

using System;
using System.Text;

namespace BiggerIsGreater.Library
{
    public class BiggerGreater : ProblemSolverBase, IProblemSolver
    {
        //################################################################################
        #region IProblemSolver Members

        void IProblemSolver.Solve(IConsole console)
        {
            Console = console;
            var caseCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < caseCount; i++)
            {
                var input = Console.ReadLine();
                FindTheBigger(input);
            }
        }

        #endregion

        //################################################################################
        #region Private Members

        private void FindTheBigger(string input)
        {
            int concatPoint = 0;
            var subToOrder = string.Empty;

            for (int i = input.Length - 1; i > 0 ; i--)
            {
                if (i > 0 && input[i] > input[i - 1])
                {
                    subToOrder = input.Substring(i - 1);
                    concatPoint = i - 1;
                    break;
                }
            }

            string ordered;
            var toOrder = PutNextCharToStart(subToOrder);

            if (!string.IsNullOrEmpty(toOrder))
            {
                ordered = OrderString(toOrder);
                Console.WriteLine($"{input.Substring(0, concatPoint)}{ordered}");
            }
            else
            {
                Console.WriteLine("no answer");
            }
        }

        private string PutNextCharToStart(string subStr)
        {
            if (string.IsNullOrEmpty(subStr))
                return string.Empty;

            var subStrArray = subStr.ToCharArray();
            int difference = 'z' + 1;
            int nextBigCharIndex = 0;
            char firstChar = subStr[0];
            char nextBigChar;

            for (int i = 1; i < subStr.Length; i++)
            {
                if (subStr[i] > subStr[0] && subStr[i] - subStr[0] < difference)
                {
                    difference = subStr[i] - subStr[0];
                    nextBigChar = subStr[i];
                    nextBigCharIndex = i;
                }
            }


            subStrArray[0] = subStr[nextBigCharIndex];
            subStrArray[nextBigCharIndex] = firstChar;

            return string.Concat(subStrArray);
        }

        private string OrderString(string toOrder)
        {
            var index = 0;
            var charInt = new int[toOrder.Length];

            foreach (var c in toOrder)
            {
                charInt[index] = c;
                index++;
            }

            QuickSort(charInt, 1, charInt.Length - 1);

            var ordered = string.Empty;

            foreach (var ascii in charInt)
            {
                ordered += (char)ascii;
            }

            return ordered;
        }

        private void QuickSort(int[] arr, int start, int end)
        {
            int i;
            if (start < end)
            {
                i = Partition(arr, start, end);

                QuickSort(arr, start, i - 1);
                QuickSort(arr, i + 1, end);
            }
        }

        private int Partition(int[] arr, int start, int end)
        {
            int temp;
            int p = arr[end];
            int i = start - 1;

            for (int j = start; j <= end - 1; j++)
            {
                if (arr[j] <= p)
                {
                    i++;
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            temp = arr[i + 1];
            arr[i + 1] = arr[end];
            arr[end] = temp;
            return i + 1;
        }

        #endregion
    }
}
