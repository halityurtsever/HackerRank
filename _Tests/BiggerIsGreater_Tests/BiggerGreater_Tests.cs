using BiggerIsGreater.Library;

using CodeHelpers;

using NUnit.Framework;

namespace BiggerIsGreater_Tests
{
    [TestFixture]
    public class BiggerGreater_Tests : TestBase
    {
        //################################################################################
        #region Tests

        [Test]
        public void TestCase_01()
        {
            TestRunner<BiggerGreater>("input_01.txt", "output_01.txt");
        }

        [Test]
        public void TestCase_02()
        {
            TestRunner<BiggerGreater>("input_02.txt", "output_02.txt");
        }

        [Test]
        public void TestCase_03()
        {
            TestRunner<BiggerGreater>("input_03.txt", "output_03.txt");
        }

        #endregion
    }
}
