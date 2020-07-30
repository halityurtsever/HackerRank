using CodeHelpers;

namespace CubeSummation.Library
{
    public class CubeCalculator : ProblemSolverBase, IProblemSolver
    {
        //################################################################################
        #region IProblemSolver Members

        void IProblemSolver.Solve(IConsole console)
        {
            Console = console;

            ReadTestData();
        }

        #endregion

        //################################################################################
        #region Private Members

        private void ReadTestData()
        {
            int caseCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < caseCount; i++)
            {
                var testInfo = Console.ReadLine().Split(' ');

                var arraySize = int.Parse(testInfo[0]);
                var array = new long[arraySize][][];

                for (int x = 0; x < arraySize; x++)
                {
                    array[x] = new long[arraySize][];

                    for (int y = 0; y < arraySize; y++)
                    {
                        array[x][y] = new long[arraySize];
                    }
                }

                var queryCount = int.Parse(testInfo[1]);
                for (int j = 0; j < queryCount; j++)
                {
                    var query = Console.ReadLine();
                    RunQuery(array, query);
                }
            }
        }

        private void RunQuery(long[][][] array, string query)
        {
            var queryParams = query.Split(' ');

            if (queryParams[0] == "UPDATE")
            {
                var x = int.Parse(queryParams[1]) - 1;
                var y = int.Parse(queryParams[2]) - 1;
                var z = int.Parse(queryParams[3]) - 1;
                var value = long.Parse(queryParams[4]);

                array[x][y][z] = value;
            }
            else if (queryParams[0] == "QUERY")
            {
                var x1 = int.Parse(queryParams[1]) - 1;
                var y1 = int.Parse(queryParams[2]) - 1;
                var z1 = int.Parse(queryParams[3]) - 1;

                var x2 = int.Parse(queryParams[4]) - 1;
                var y2 = int.Parse(queryParams[5]) - 1;
                var z2 = int.Parse(queryParams[6]) - 1;

                CalculateSum(array, x1, y1, z1, x2, y2, z2);
            }
        }

        private void CalculateSum(long[][][] array, int x1, int y1, int z1, int x2, int y2, int z2)
        {
            long total = 0;

            // Collect x
            for (int x = x1; x <= x2; x++)
            {
                // Collect y
                for (int y = y1; y <= y2; y++)
                {
                    // Collect z
                    for (int z = z1; z <= z2; z++)
                    {
                        total += array[x][y][z];
                    }
                }
            }

            Console.WriteLine(total);
        }

        #endregion
    }
}
