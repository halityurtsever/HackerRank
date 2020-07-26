using CodeHelpers;

using MorganAndString.Library;

using NUnit.Framework;

namespace MorganAndString_Tests
{
    [TestFixture]
    public class MorganStrings_Tests : TestBase
    {
        //################################################################################
        #region Tests

        [Test]
        public void TestCase_01()
        {
            TestRunner<MorganStrings>("input_01.txt", "output_01.txt");
        }

        [Test, Explicit]
        public void TestCase_02()
        {
            TestRunner<MorganStrings>("input_02.txt", "output_02.txt");
        }

        [Test]
        public void TestCase_03()
        {
            TestRunner<MorganStrings>("input_03.txt", "output_03.txt");
        }

        [Test]
        public void TestCase_04()
        {
            TestRunner<MorganStrings>("input_04.txt", "output_04.txt");
        }

        [Test]
        public void TestCase_05()
        {
            TestRunner<MorganStrings>("input_05.txt", "output_05.txt");
        }

        [Test, Explicit]
        public void TestCase_06()
        {
            TestRunner<MorganStrings>("input_06.txt", "output_06.txt");
        }

        #endregion
    }
}
