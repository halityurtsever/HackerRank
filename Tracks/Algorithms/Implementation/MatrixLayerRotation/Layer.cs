using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLayerRotation
{
    /// <summary>
    /// A linked list implementation
    /// </summary>
    internal class Layer
    {
        //################################################################################
        #region Fields

        private Node m_Head;
        private Node m_Tail;
        private Node m_CurrentNode;
        private int m_LayerSize = 0;

        #endregion

        //################################################################################
        #region Properties

        internal Node Head
        {
            get
            {
                return m_Head;
            }
        }

        internal Node Tail
        {
            get
            {
                return m_Tail;
            }
        }

        internal Node NextNode
        {
            get
            {
                if (m_CurrentNode == null)
                {
                    m_CurrentNode = m_Head;
                }
                else
                {
                    m_CurrentNode = m_CurrentNode.Next;
                }

                return m_CurrentNode;
            }
        }

        #endregion

        //################################################################################
        #region Internal Implementation

        internal void RotateLayer(int rotationCount)
        {
            int rotationMod = rotationCount % m_LayerSize;

            Node currentHead;
            Node currentTail;
            for (int i = 0; i < rotationMod; i++)
            {
                currentHead = m_Head.Next;
                currentTail = m_Head;

                m_Head = currentHead;
                m_Tail = currentTail;
            }
        }

        internal void AddNode(Node newNode)
        {
            m_LayerSize++;

            //layer is empty
            if (m_Head == null)
            {
                m_Head = newNode;
                m_Tail = newNode;
                return;
            }

            //old tail points to new node as its next node
            m_Tail.Next = newNode;

            //new node assigned as tail
            m_Tail = newNode;

            //new tail points to head 
            m_Tail.Next = Head;
        }

        #endregion
    }
}
