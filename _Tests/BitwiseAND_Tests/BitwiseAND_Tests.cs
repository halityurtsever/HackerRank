using CodeHelpers;

using HackerRank.Tutorials._30DaysOfCode.BitwiseAND;

using NUnit.Framework;

namespace BitwiseAND_Tests
{
    [TestFixture]
    public class BitwiseAND_Tests : TestBase
    {
        //################################################################################
        #region Tests

        [Test]
        public void TestCase_01()
        {
            TestRunner<BitwiseAND>("input_01.txt", "output_01.txt");
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