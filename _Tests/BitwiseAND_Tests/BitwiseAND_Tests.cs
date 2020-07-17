using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestHelper;

namespace HackerRank.Tutorials._30DaysOfCode.BitwiseAND.Tests
{
    [TestClass()]
    public class BitwiseAND_Tests : TestBase<BitwiseAND>
    {
        //################################################################################
        #region Tests

        [TestMethod]
        public void BitwiseAND_TestCase_01()
        {
            TestRunner("input_01.txt", "output_01.txt");
        }

        #endregion
    }
}