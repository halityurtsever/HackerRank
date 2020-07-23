using CodeHelpers;

using NUnit.Framework;

using QueueTwoStacks.Library;

namespace QueueTwoStacks_Tests
{
    [TestFixture]
    public class QueueTwoStacks_Tests : TestBase
    {
        //################################################################################
        #region Tests

        [Test]
        public void TestCase_01()
        {
            TestRunner<TwoStacksQueuer>("input_01.txt", "output_01.txt");
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
