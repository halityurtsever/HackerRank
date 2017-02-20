using System;

namespace BinaryNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Convert.ToInt32(Console.ReadLine());
            var binaryFormat = Convert.ToString(input, 2);
            var maxCount = 0;
            var tempCount = 0;
            for (int i = 0; i < binaryFormat.Length; i++)
            {
                if (binaryFormat[i].ToString() == "0")
                {
                    tempCount = 0;
                }
                else
                {
                    tempCount++;
                    if (tempCount > maxCount)
                    {
                        maxCount = tempCount;
                    }
                }
            }
            Console.WriteLine(maxCount);
        }
    }
}
