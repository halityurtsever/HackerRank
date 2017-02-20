using CodeHelpers;
using System;
using System.Collections.Generic;
using KingdomConnectivity;

namespace HackerRank.Tracks.Algorithms.GraphTheory.KingdomConnectivity
{
    public static class Program_KingdomConnectivity
    {
        //################################################################################
        #region Fields

        private static IConsole s_Console;
        private static int m_LastCity;
        private static readonly HashSet<int> m_CurrentPathList = new HashSet<int>();
        private static readonly Dictionary<int, City> m_ConnectionNetwork = new Dictionary<int, City>();

        #endregion

        //################################################################################
        #region Main Method

        static void Main()
        {
            s_Console = new ConsoleWrapper();
            var initials = s_Console.ReadLine().Split(' ');
            var cityCount = Convert.ToInt32(initials[0]);
            var connectionCount = Convert.ToInt32(initials[1]);

            ExecuteTask(s_Console, cityCount, connectionCount);

            CleanUp();
        }

        #endregion

        //################################################################################
        #region Public Implementation

        public static void ExecuteTask(IConsole console, int cityCount, int connectionCount)
        {
            s_Console = console;
            m_LastCity = cityCount;
            CreateNetwork(console, cityCount, connectionCount);
            try
            {
                var pathCount = FindPathCount(1);
                console.WriteLine(pathCount);
            }
            catch (Exception ex)
            {
                console.WriteLine(ex.Message);
            }
        }

        public static void CleanUp()
        {
            m_ConnectionNetwork.Clear();
            m_CurrentPathList.Clear();
            m_LastCity = 0;
        }

        #endregion

        //################################################################################
        #region Private Implementation

        private static void CreateNetwork(IConsole console, int cityCount, int connectionCount)
        {
            for (int i = 0; i < connectionCount; i++)
            {
                //read connection data from console
                var connectionData = console.ReadLine().Split(' ');
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

        private static long FindPathCount(int cityId)
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
                    City nextCity;

                    if (nextCityId != m_LastCity)
                    {
                        //next city is death end
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

        private static void InfinitePathCheck()
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

        #endregion
    }
}
