using System.Collections.Generic;

namespace KingdomConnectivity
{
    internal class City
    {
        //################################################################################
        #region Fields

        private int m_CityId;
        private bool m_IsLoopedCity;
        private bool m_IsReachedEnd;
        private bool m_IsPathCountCalculated;
        private int m_TotalPathFormCity = 0;
        private Dictionary<int, int> m_ConnectedCityList = new Dictionary<int, int>();

        #endregion

        //################################################################################
        #region Constructor

        public City(int id)
        {
            m_CityId = id;
        }

        #endregion

        //################################################################################
        #region Properties

        internal int Id => m_CityId;

        internal Dictionary<int, int> Connections => m_ConnectedCityList;

        internal bool IsLoopedCity
        {
            get { return m_IsLoopedCity; }
            set { m_IsLoopedCity = value; }
        }

        internal bool IsReachedEnd
        {
            get { return m_IsReachedEnd; }
            set { m_IsReachedEnd = value; }
        }

        internal bool IsPathCountCalculated
        {
            get { return m_IsPathCountCalculated; }
            set { m_IsPathCountCalculated = value; }
        }

        internal long TotalPathFromCity
        {
            get
            { return m_IsLoopedCity ? 0 : m_TotalPathFormCity; }
            set
            {
                var modTotal = m_TotalPathFormCity + (int)(value % 1e9);
                m_TotalPathFormCity = (int)(modTotal % 1e9);
            }
        }

        #endregion

        //################################################################################
        #region Internal Implementation

        internal void AddConnectedCity(int connectedCity)
        {
            if (m_ConnectedCityList.ContainsKey(connectedCity))
            {
                m_ConnectedCityList[connectedCity]++;
            }
            else
            {
                m_ConnectedCityList.Add(connectedCity, 1);
            }
        }

        #endregion
    }
}
