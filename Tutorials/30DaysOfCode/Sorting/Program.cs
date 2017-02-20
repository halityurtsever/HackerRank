using System;

namespace HackerRank.Tutorials._30DaysOfCode.Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            var arraySize = Convert.ToInt32(Console.ReadLine());
            var array = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
            var swapCount = 0;
            var isSwapped = true;

            while (isSwapped)
            {
                isSwapped = false;

                for (int i = 0; i < arraySize - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        var temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;

                        swapCount++;
                        isSwapped = true;
                    }
                }
            }

            Console.WriteLine($"Array is sorted in {swapCount} swaps.");
            Console.WriteLine($"First Element: {array[0]}");
            Console.WriteLine($"Last Element: {array[arraySize - 1]}");
        }
    }
}
