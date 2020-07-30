using CodeHelpers;

using CubeSummation.Library;

using NUnit.Framework;

namespace CodeSummation_Tests
{
    [TestFixture]
    public class CubeCalculator_Tests : TestBase
    {
        //################################################################################
        #region Tests

        [Test]
        public void TestCase_01()
        {
            TestRunner<CubeCalculator>("input_01.txt", "output_01.txt");
        }

        [Test, Explicit]
        public void TestCase_02()
        {
            TestRunner<CubeCalculator>("input_02.txt", "output_02.txt");
        }

        #endregion
    }
}
