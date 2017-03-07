
namespace MatrixLayerRotation
{
    internal class Node
    {
        //################################################################################
        #region Fields

        private Node m_Next;
        private int m_Value;

        #endregion

        //################################################################################
        #region Constructor

        public Node(int value)
        {
            m_Next = null;
            m_Value = value;
        }

        #endregion

        //################################################################################
        #region Properties

        internal int Value
        {
            get
            {
                return m_Value;
            }
        }

        internal Node Next
        {
            get
            {
                return m_Next;
            }

            set
            {
                m_Next = value;
            }
        }

        #endregion
    }
}
