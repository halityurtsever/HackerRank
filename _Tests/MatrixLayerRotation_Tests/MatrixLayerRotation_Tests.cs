using CodeHelpers;

using MatrixLayerRotation.Library;

using NUnit.Framework;

namespace MatrixLayerRotation_Tests
{
    [TestFixture]
    public class MatrixLayerRotation_Tests : TestBase
    {
        //################################################################################
        #region Tests

        [Test]
        public void TestCase_01()
        {
            TestRunner<MatrixRotater>(Assertion, "input_01.txt", "output_01.txt");
        }

        [Test]
        public void TestCase_02()
        {
            TestRunner<MatrixRotater>(Assertion, "input_02.txt", "output_02.txt");
        }

        [Test]
        public void TestCase_03()
        {
            TestRunner<MatrixRotater>(Assertion, "input_03.txt", "output_03.txt");
        }

        [Test]
        public void TestCase_04()
        {
            TestRunner<MatrixRotater>(Assertion, "input_04.txt", "output_04.txt");
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