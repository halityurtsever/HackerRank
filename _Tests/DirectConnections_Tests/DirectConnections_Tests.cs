using HackerRank.Tracks.DataStructures.Advanced.DirectConnections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestHelper;

namespace DirectConnections_Tests
{
    [TestClass]
    public class DirectConnections_Tests : TestBase
    {
        //################################################################################
        #region Tests

        [TestMethod]
        public void DirectConnections_TestCase_01()
        {
            TestRunner("input_01.txt", "output_01.txt");
        }

        [TestMethod]
        public void DirectConnections_TestCase_02()
        {
            TestRunner("input_02.txt", "output_02.txt");
        }

        [TestMethod]
        public void DirectConnections_TestCase_03()
        {
            TestRunner("input_03.txt", "output_03.txt");
        }

        [TestMethod]
        public void DirectConnections_TestCase_04()
        {
            TestRunner("input_04.txt", "output_04.txt");
        }

        #endregion
    }
}
