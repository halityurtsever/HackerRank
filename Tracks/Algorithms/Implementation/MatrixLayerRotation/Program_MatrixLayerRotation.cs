using CodeHelpers;
using MatrixLayerRotation;
using System;
using System.Collections.Generic;

namespace HackerRank.Tracks.Algorithms.Implementation.MatrixLayerRotation
{
    public class Program_MatrixLayerRotation
    {
        //################################################################################
        #region Fields

        private static int m_RowCount;
        private static int m_ColCount;
        private static int m_RotationCount;
        private static int[,] m_RotationMatrix;
        private static List<Layer> m_LayerList = new List<Layer>();

        #endregion

        //################################################################################
        #region Public Implementation

        public static void Main(string[] args)
        {
            IConsole console = new ConsoleWrapper();
            ExecuteTask(console);
        }

        public static void ExecuteTask(IConsole console)
        {
            //read inputs from console
            var initialValues = console.ReadLine().Split(' ');
            m_RowCount = Convert.ToInt32(initialValues[0]);
            m_ColCount = Convert.ToInt32(initialValues[1]);
            m_RotationCount = Convert.ToInt32(initialValues[2]);

            CreateMatrix(console);

            RotateMatrix();
            UpdateMatrix();
            PrintMatrix(console);

            //Clean up
            m_LayerList.Clear();
        }

        #endregion

        //################################################################################
        #region Private Implementation

        private static void RotateMatrix()
        {
            //it's guaranteed that min edge will be even
            int layerCount = Math.Min(m_RowCount, m_ColCount) / 2;

            for (int i = 0; i < layerCount; i++)
            {
                //create an empty layer
                Layer layer = new Layer();

                //read north. row is fixed, column changes to backward
                for (int n = i; n <= m_ColCount - 1 - i; n++)
                {
                    layer.AddNode(new Node(m_RotationMatrix[i, n]));
                }

                //read east. column is fixed, row changes to backward
                for (int e = i + 1; e <= m_RowCount - 2 - i; e++)
                {
                    layer.AddNode(new Node(m_RotationMatrix[e, m_ColCount - 1 - i]));
                }

                //read south. row is fixed, column changes to forward
                for (int s = m_ColCount - 1 - i; s >= i; s--)
                {
                    layer.AddNode(new Node(m_RotationMatrix[m_RowCount - 1 - i, s]));
                }

                //read west. column is fixed, row changes to forward
                for (int w = m_RowCount - 2 - i; w >= i + 1; w--)
                {
                    layer.AddNode(new Node(m_RotationMatrix[w, i]));
                }

                layer.RotateLayer(m_RotationCount);
                m_LayerList.Add(layer);
            }
        }

        private static void UpdateMatrix()
        {
            for (int i = 0; i < m_LayerList.Count; i++)
            {
                //read north. row is fixed, column changes to backward
                for (int n = i; n <= m_ColCount - 1 - i; n++)
                {
                    m_RotationMatrix[i, n] = m_LayerList[i].NextNode.Value;
                }

                //read east. column is fixed, row changes to backward
                for (int e = i + 1; e <= m_RowCount - 2 - i; e++)
                {
                    m_RotationMatrix[e, m_ColCount - 1 - i] = m_LayerList[i].NextNode.Value;
                }

                //read south. row is fixed, column changes to forward
                for (int s = m_ColCount - 1 - i; s >= i; s--)
                {
                    m_RotationMatrix[m_RowCount - 1 - i, s] = m_LayerList[i].NextNode.Value;
                }

                //read west. column is fixed, row changes to forward
                for (int w = m_RowCount - 2 - i; w >= i + 1; w--)
                {
                    m_RotationMatrix[w, i] = m_LayerList[i].NextNode.Value;
                }
            }
        }

        private static void PrintMatrix(IConsole console)
        {
            string row = string.Empty;

            for (int i = 0; i < m_RowCount; i++)
            {
                for (int j = 0; j < m_ColCount; j++)
                {
                    row += $"{m_RotationMatrix[i, j]} ";
                }
                console.WriteLine(row.TrimEnd());
                row = string.Empty;
            }
        }

        private static void CreateMatrix(IConsole console)
        {
            m_RotationMatrix = new int[m_RowCount, m_ColCount];

            for (int row = 0; row < m_RowCount; row++)
            {
                var rowData = console.ReadLine().Split(' ');

                for (int col = 0; col < m_ColCount; col++)
                {
                    m_RotationMatrix[row, col] = Convert.ToInt32(rowData[col]);
                }
            }
        }

        #endregion
    }
}
