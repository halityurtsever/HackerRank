using CodeHelpers;

using System;
using System.Collections.Generic;

namespace KingdomConnectivity.Library
{
    public class ConnectKingdoms : ProblemSolverBase, IProblemSolver
    {
        //################################################################################
        #region Fields

        private int m_LastCity;
        private readonly HashSet<int> m_CurrentPathList = new HashSet<int>();
        private readonly Dictionary<int, City> m_ConnectionNetwork = new Dictionary<int, City>();

        #endregion

        //################################################################################
        #region IProblemSolver Members

        void IProblemSolver.Solve(IConsole console)
        {
            Console = console;
            SolveProblem();
        }

        #endregion

        //################################################################################
        #region Private Members

        private void SolveProblem()
        {
            var initials = Console.ReadLine().Split(' ');

            m_LastCity = Convert.ToInt32(initials[0]);
            var connectionCount = Convert.ToInt32(initials[1]);

            CreateNetwork(connectionCount);
            try
            {
                var pathCount = FindPathCount(1);
                Console.WriteLine(pathCount);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            CleanUp();
        }

        private void CreateNetwork(int connectionCount)
        {
            for (int i = 0; i < connectionCount; i++)
            {
                //read connection data from console
                var connectionData = Console.ReadLine().Split(' ');
                int fromCity = Convert.ToInt32(connectionData[0]);
                int toCity = Convert.ToInt32(connectionData[1]);

                //add cities to connection network list
                if (!m_ConnectionNetwork.ContainsKey(fromCity))
                {
                    m_ConnectionNetwork.Add(fromCity, new City(fromCity));
                }
                m_ConnectionNetwork[fromCity].AddConnectedCity(toCity);
            }
        }

        private long FindPathCount(int cityId)
        {
            //reached to end
            if (cityId == m_LastCity)
            {
                //mark all cities in current path list as reachedEnd
                foreach (var id in m_CurrentPathList)
                {
                    City city = m_ConnectionNetwork[id];
                    city.IsReachedEnd = true;
                }

                InfinitePathCheck();
                return 1;
            }

            //loop detected
            if (m_CurrentPathList.Contains(cityId))
            {
                bool isLoopedFound = false;
                //mark all cities in current path list as reachedEnd
                foreach (var id in m_CurrentPathList)
                {
                    if (isLoopedFound || id == cityId)
                    {
                        isLoopedFound = true;
                        City city = m_ConnectionNetwork[id];
                        city.IsLoopedCity = true;
                    }
                }

                InfinitePathCheck();
                return 0;
            }

            if (m_ConnectionNetwork.ContainsKey(cityId))
            {
                //add current city id to path list
                m_CurrentPathList.Add(cityId);

                City currentCity = m_ConnectionNetwork[cityId];

                //if total paths from current city is calculated
                if (currentCity.IsPathCountCalculated)
                {
                    m_CurrentPathList.Remove(cityId);
                    return currentCity.TotalPathFromCity;
                }

                //if total paths from current city is not calculated, iterate over the city
                foreach (var city in currentCity.Connections)
                {
                    int nextCityId = city.Key;
                    int pathToNextCity = city.Value;

                    if (nextCityId != m_LastCity)
                    {
                        //next city is death end
                        City nextCity;
                        if (!m_ConnectionNetwork.TryGetValue(nextCityId, out nextCity)) continue;

                        //next city is looped city
                        if (nextCity.IsLoopedCity) continue;
                    }

                    long pathFromNextCity = FindPathCount(nextCityId);
                    currentCity.TotalPathFromCity = pathToNextCity * pathFromNextCity;
                }

                //remove city from path list and return total path from city
                m_CurrentPathList.Remove(cityId);
                currentCity.IsPathCountCalculated = true;
                return currentCity.TotalPathFromCity;
            }

            //no connection to city
            return 0;
        }

        private void InfinitePathCheck()
        {
            foreach (var cityId in m_CurrentPathList)
            {
                City city = m_ConnectionNetwork[cityId];

                if (city.IsLoopedCity && city.IsReachedEnd)
                {
                    throw new Exception("INFINITE PATHS");
                }
            }
        }

        private void CleanUp()
        {
            m_ConnectionNetwork.Clear();
            m_CurrentPathList.Clear();
            m_LastCity = 0;
        }

        #endregion
    }
}
