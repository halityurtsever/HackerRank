using System.Collections.Generic;

namespace HackerRank.Competes.WeekOfCode30.AGraphProblem
{
    internal class Vertice
    {
        //################################################################################
        #region Fields

        private readonly int m_Id;
        private List<int> m_Neighbours = new List<int>();

        #endregion

        //################################################################################
        #region Constructor

        public Vertice(int id)
        {
            m_Id = id;
        }

        #endregion

        //################################################################################
        #region Properties

        public int Id
        {
            get { return m_Id; }
        }

        #endregion

        //################################################################################
        #region Internal Implementation

        internal void AddNeighbour(int id)
        {
            m_Neighbours.Add(id);
        }

        #endregion
    }
}
