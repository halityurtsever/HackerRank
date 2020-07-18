using CodeHelpers;

using DirectConnections.Library;

using NUnit.Framework;

namespace DirectConnections_Tests
{
    [TestFixture]
    public class DirectConnections_Tests : TestBase
    {
        //################################################################################
        #region Tests

        [Test]
        public void TestCase_01()
        {
            TestRunner<DirectConnectionsCalculator>("input_01.txt", "output_01.txt");
        }

        [Test]
        public void TestCase_02()
        {
            TestRunner<DirectConnectionsCalculator>("input_02.txt", "output_02.txt");
        }

        [Test]
        public void TestCase_03()
        {
            TestRunner<DirectConnectionsCalculator>("input_03.txt", "output_03.txt");
        }

        [Test]
        public void TestCase_04()
        {
            TestRunner<DirectConnectionsCalculator>("input_04.txt", "output_04.txt");
        }

        #endregion
    }
}
