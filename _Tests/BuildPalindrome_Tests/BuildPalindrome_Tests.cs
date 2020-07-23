using BuildPalindrome.Library;

using CodeHelpers;

using NUnit.Framework;

namespace BuildPalindrome_Tests
{
    [TestFixture]
    public class BuildPalindrome_Tests : TestBase
    {
        //################################################################################
        #region Tests

        [Test]
        public void TestCase_01()
        {
            TestRunner<PalindromeBuilder>("input_01.txt", "output_01.txt");
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