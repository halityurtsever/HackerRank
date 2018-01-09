using System;
using System.Collections.Generic;
using CodeHelpers;

namespace HackerRank.Tracks.DataStructures.Advanced.DirectConnections
{
    public class DirectConnections : ProblemBase, IProblemSolver
    {
        //################################################################################
        #region Fields

        private const long Modulo = 1000000007;
        private readonly IList<Game> m_Games = new List<Game>();

        #endregion

        //################################################################################
        #region IProblemSolver Implementation

        void IProblemSolver.Execute(IConsole console)
        {
            Console = console;
            ReadInputs();
            SolveProblem();
        }

        #endregion

        //################################################################################
        #region Private Implementation

        private void SolveProblem()
        {
            foreach (var game in m_Games)
            {
                CalculateCableLength(game);
            }
        }

        private void ReadInputs()
        {
            var gameCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < gameCount; i++)
            {
                var game = new Game
                {
                    CityCount = Convert.ToInt32(Console.ReadLine()),
                    CityLocations = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse),
                    CityPopulations = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse)
                };

                m_Games.Add(game);
            }
        }

        private void CalculateCableLength(Game game)
        {
            long totalLength = 0;

            for (int i = 0; i < game.CityCount; i++)
            {
                for (int j = i + 1; j < game.CityCount; j++)
                {
                    long distance = Math.Abs(game.CityLocations[j] - game.CityLocations[i]);
                    long iPop = game.CityPopulations[i], jPop = game.CityPopulations[j];
                    long population = iPop > jPop ? iPop : jPop;
                    long currentLength = distance * population % Modulo;

                    totalLength = (totalLength + currentLength) % Modulo;
                }
            }

            Console.WriteLine(totalLength);
        }

        #endregion
    }
}
