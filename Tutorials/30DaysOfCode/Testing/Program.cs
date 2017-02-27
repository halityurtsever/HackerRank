using System;
using System.Collections.Generic;

namespace HackerRank.Tutorials._30DaysOfCode.Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            List<int> distinctStudentCountList = new List<int>();
            Dictionary<string, string> inputs = new Dictionary<string, string>();
            bool isYes = true;
            int index = 0;

            Console.WriteLine(5);

            //generate inputs/outputs
            while (index < 5)
            {
                string inputLine1 = string.Empty;
                string inputLine2 = string.Empty;

                int studentCount = rnd.Next(3, 21);
                //guarantees distinct student count for each test case
                if (distinctStudentCountList.Contains(studentCount))
                {
                    continue;
                }
                distinctStudentCountList.Add(studentCount);

                int attendanceThreshold = rnd.Next(1, studentCount + 1);
                inputLine1 = $"{studentCount} {attendanceThreshold}";

                int attendanceCount = 2;

                for (int j = 0; j < studentCount - 3; j++)
                {
                    int newAttendance = rnd.Next(-3, 4);
                    inputLine2 += $"{newAttendance} ";
                    if (newAttendance < 1)
                    {
                        attendanceCount++;
                    }
                }
                //guarantees zero(0), positive and negative on each test case
                inputLine2 += $"-1 ";
                inputLine2 += $"0 ";
                inputLine2 += $"1";

                if (attendanceCount < attendanceThreshold && isYes)
                {
                    inputs.Add(inputLine1, inputLine2);
                    index++;
                    isYes = false;
                }
                else if (attendanceCount >= attendanceThreshold && !isYes)
                {
                    inputs.Add(inputLine1, inputLine2);
                    index++;
                    isYes = true;
                }
            }

            //print inputs/outputs
            foreach (var input in inputs)
            {
                Console.WriteLine($"{input.Key}");
                Console.WriteLine($"{input.Value}");
            }
        }
    }
}
