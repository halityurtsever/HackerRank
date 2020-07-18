using CodeHelpers;

using KingdomConnectivity.Library;

using NUnit.Framework;

namespace KingdomConnectivity_Tests
{
    [TestFixture]
    public class KingdomConnectivity_Tests : TestBase
    {
        //################################################################################
        #region Tests

        [Test]
        public void TestCase_01()
        {
            TestRunner<ConnectKingdoms>(Assertion, "input_01.txt", "output_01.txt");
        }

        [Test]
        public void TestCase_02()
        {
            TestRunner<ConnectKingdoms>(Assertion, "input_02.txt", "output_02.txt");
        }

        [Test]
        public void TestCase_03()
        {
            TestRunner<ConnectKingdoms>(Assertion, "input_03.txt", "output_03.txt");
        }

        [Test]
        public void TestCase_04()
        {
            TestRunner<ConnectKingdoms>(Assertion, "input_04.txt", "output_04.txt");
        }

        [Test]
        public void TestCase_05()
        {
            TestRunner<ConnectKingdoms>(Assertion, "input_05.txt", "output_05.txt");
        }

        [Test]
        public void TestCase_06()
        {
            TestRunner<ConnectKingdoms>(Assertion, "input_06.txt", "output_06.txt");
        }

        [Test]
        public void TestCase_07()
        {
            TestRunner<ConnectKingdoms>(Assertion, "input_07.txt", "output_07.txt");
        }

        [Test]
        public void TestCase_08()
        {
            TestRunner<ConnectKingdoms>(Assertion, "input_08.txt", "output_08.txt");
        }

        [Test]
        public void TestCase_09()
        {
            TestRunner<ConnectKingdoms>(Assertion, "input_09.txt", "output_09.txt");
        }

        [Test]
        public void TestCase_10()
        {
            TestRunner<ConnectKingdoms>(Assertion, "input_10.txt", "output_10.txt");
        }

        [Test]
        public void TestCase_11()
        {
            TestRunner<ConnectKingdoms>(Assertion, "input_11.txt", "output_11.txt");
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