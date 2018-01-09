using System.Collections.Generic;

namespace HackerRank.Tracks.DataStructures.Advanced.DirectConnections
{
    internal class Game
    {
        public int CityCount { get; set; }

        public IList<int> CityLocations { get; set; } = new List<int>();

        public IList<int> CityPopulations { get; set; } = new List<int>();
    }
}
