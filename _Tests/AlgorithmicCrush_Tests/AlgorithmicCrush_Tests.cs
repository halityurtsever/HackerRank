using CodeHelpers;

using AlgorithmicCrush.Library;

using NUnit.Framework;

namespace AlgorithmicCrush_Tests
{
    [TestFixture]
    public class AlgorithmicCrush_Tests : TestBase
    {
        //################################################################################
        #region Tests

        [Test]
        public void TestCase_01()
        {
            TestRunner<AlgorithmicCrusher>("input_01.txt", "output_01.txt");
        }

        [Test]
        public void TestCase_02()
        {
            TestRunner<AlgorithmicCrusher>("input_02.txt", "output_02.txt");
        }

        [Test]
        public void TestCase_03()
        {
            TestRunner<AlgorithmicCrusher>("input_03.txt", "output_03.txt");
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