using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestHelper;

namespace HackerRank.Tracks.Algorithms.Strings.BuildPalindrome.Tests
{
    [TestClass]
    public class BuildPalindrome_Tests : TestBase<BuildPalindrome>
    {
        //################################################################################
        #region Tests

        [TestMethod]
        public void BuildPalindrome_TestCase_01()
        {
            TestRunner("input_01.txt", "output_01.txt");
        }

        #endregion
    }
}