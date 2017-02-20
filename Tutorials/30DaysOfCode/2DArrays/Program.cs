using System;

namespace _2DArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //var dataTempArray = new string[6];
            //dataTempArray[0] = "0 -4 -6 0 -7 -6";
            //dataTempArray[1] = "-1 -2 -6 -8 -3 -1";
            //dataTempArray[2] = "-8 -4 -2 -8 -8 -6";
            //dataTempArray[3] = "-3 -1 -2 -5 -7 -4";
            //dataTempArray[4] = "-3 -5 -3 -6 -6 -6";
            //dataTempArray[5] = "-3 -6 0 -8 -6 -7";

            int[,] dataArray = new int[6, 6];
            for (int i = 0; i < 6; i++)
            {
                var inputData = /*dataTempArray[i].Split(' '); /*/Console.ReadLine().Split(' ');
                for (int j = 0; j < 6; j++)
                {
                    dataArray[i, j] = Convert.ToInt32(inputData[j]);
                }
            }

            var startColumn = 0;
            var startRow = 0;
            var maxTotal = 0;
            for (int i = 0; i < 16; i++)
            {
                startRow = i / 4;
                startColumn = i % 4;

                //top
                var c1 = dataArray[startRow, startColumn];
                var c2 = dataArray[startRow, startColumn + 1];
                var c3 = dataArray[startRow, startColumn + 2];

                //middle
                var c4 = dataArray[startRow + 1, startColumn + 1];

                //bottom
                var c5 = dataArray[startRow + 2, startColumn];
                var c6 = dataArray[startRow + 2, startColumn + 1];
                var c7 = dataArray[startRow + 2, startColumn + 2];

                var total = c1 + c2 + c3 + c4 + c5 + c6 + c7;

                if (i == 0)
                {
                    maxTotal = total;
                }

                if (total > maxTotal)
                {
                    maxTotal = total;
                }
            }

            Console.WriteLine(maxTotal);
            //Console.ReadLine();
        }
    }
}
