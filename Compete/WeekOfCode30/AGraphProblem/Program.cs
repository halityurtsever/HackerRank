using System;
using System.Collections.Generic;

namespace HackerRank.Competes.WeekOfCode30.AGraphProblem
{
    public class Program
    {
        //################################################################################
        #region Fields

        private static List<Vertice> m_VerticeList = new List<Vertice>();

        #endregion

        //################################################################################
        #region Public Implementation

        public static void Main(string[] args)
        {
            //read values from Console
            int verticeCount = Convert.ToInt32(Console.ReadLine());

            //fill the matrix
            CreateGraph(verticeCount);
        }

        #endregion

        //################################################################################
        #region Private Implementation

        private static void CreateGraph(int size)
        {
            for (int i = 0; i < size; i++)
            {
                int[] row = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                for (int j = 0; j < size; j++)
                {
                    Vertice vertice = new Vertice(i + 1);
                    m_VerticeList.Add(vertice);
                    if (row[j] == 1)
                    {
                        vertice.AddNeighbour(j + 1);
                    }
                }
            }
        }

        #endregion
    }
}
