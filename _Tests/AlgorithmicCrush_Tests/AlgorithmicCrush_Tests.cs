using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestHelper;

namespace HackerRank.Tracks.DataStructures.Arrays.AlgorithmicCrush.Tests
{
    [TestClass]
    public class AlgorithmicCrush_Tests : TestBase<AlgorithmicCrush>
    {
        //################################################################################
        #region Tests

        [TestMethod]
        public void AlgorithmicCrush_TestCase_01()
        {
            TestRunner("input_01.txt", "output_01.txt");
        }

        [TestMethod]
        public void AlgorithmicCrush_TestCase_02()
        {
            TestRunner("input_02.txt", "output_02.txt");
        }

        [TestMethod]
        public void AlgorithmicCrush_TestCase_03()
        {
            TestRunner("input_03.txt", "output_03.txt");
        }

        #endregion
    }
}