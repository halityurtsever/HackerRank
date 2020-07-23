using CodeHelpers;

using NUnit.Framework;

using TheCoinChangeProblem.Library;

namespace TheCoinChangeProblem_Tests
{
    [TestFixture]
    public class TheCoinChangeProblem_Tests : TestBase
    {
        //################################################################################
        #region Tests

        [Test, Explicit]
        public void TestCase_01()
        {
            TestRunner<TheCoinChange>("input_01.txt", "output_01.txt");
        }

        [Test, Explicit]
        public void TestCase_02()
        {
            TestRunner<TheCoinChange>("input_02.txt", "output_02.txt");
        }

        [Test, Explicit]
        public void TestCase_03()
        {
            TestRunner<TheCoinChange>("input_03.txt", "output_03.txt");
        }

        #endregion

        //################################################################################
        #region Private Members

        private void Assertion(string expected, string actual)
        {
            Assert.That(expected, Is.EqualTo(actual));
        }

        #endregion
    }
}