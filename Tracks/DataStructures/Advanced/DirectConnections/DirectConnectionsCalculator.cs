using System;
using System.Collections.Generic;

using CodeHelpers;

namespace DirectConnections.Library
{
    public class DirectConnectionsCalculator : ProblemSolverBase, IProblemSolver
    {
        //################################################################################
        #region Fields

        private const long Modulo = 1000000007;

        #endregion

        //################################################################################
        #region IProblemSolver Members

        void IProblemSolver.Solve(IConsole console)
        {
            Console = console;

            var gameCount = Convert.ToInt32(Console.ReadLine());

            for (var i = 0; i < gameCount; i++)
            {
                CalculateCableLength();
            }
        }

        #endregion

        //################################################################################
        #region Private Members

        private void CalculateCableLength()
        {
            IDictionary<int, int> cities = new Dictionary<int, int>();

            var cityCount = Convert.ToInt32(Console.ReadLine());
            var cityLocations = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var cityPopulations = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            long totalLength = 0;

            for (var i = 0; i < cityCount; i++)
            {
                //traverse all dictionary and calculate total cable length
                foreach (var city in cities)
                {
                    long distance = Math.Abs(city.Key - cityLocations[i]);
                    long population = city.Value > cityPopulations[i] ? city.Value : cityPopulations[i];
                    long currentLength = distance * population % Modulo;

                    totalLength = (totalLength + currentLength) % Modulo;
                }

                //place city location and population to cities dictionary
                cities.Add(cityLocations[i], cityPopulations[i]);
            }

            Console.WriteLine(totalLength);
        }

        #endregion
    }
}
