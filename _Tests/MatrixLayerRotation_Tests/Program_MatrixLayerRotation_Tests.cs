using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestHelper;

namespace HackerRank.Tracks.Algorithms.Implementation.MatrixLayerRotation.Tests
{
    [TestClass()]
    public class Program_MatrixLayerRotation_Tests : TestBase
    {
        //################################################################################
        #region Tests

        [TestMethod()]
        public void MatrixRotation_TestCase_01()
        {
            TestRunner("input_01.txt", "output_01.txt");
        }

        [TestMethod()]
        public void MatrixRotation_TestCase_02()
        {
            TestRunner("input_02.txt", "output_02.txt");
        }

        [TestMethod()]
        public void MatrixRotation_TestCase_03()
        {
            TestRunner("input_03.txt", "output_03.txt");
        }

        [TestMethod()]
        public void MatrixRotation_TestCase_04()
        {
            TestRunner("input_04.txt", "output_04.txt");
        }

        #endregion

        //################################################################################
        #region Private Implementation

        protected override void TestRunner(string inputFile, string outputFile)
        {
            var console = GetConsoleReader(inputFile, outputFile);

            Program_MatrixLayerRotation.ExecuteTask(console);

            var consoleWrapper = (ConsoleWrapperTest)console;

            Assert.AreEqual(consoleWrapper.ExpectedOutput.Count, consoleWrapper.ActualOutput.Count);

            for (int i = 0; i < consoleWrapper.ActualOutput.Count; i++)
            {
                string expectedMaxValue = ((IConsoleTest)console).ReadLineFromExpectedOutput();
                string actualMaxValue = ((IConsoleTest)console).ReadLineFromActualOutput();

                Assert.AreEqual(expectedMaxValue, actualMaxValue);
            }
        }

        #endregion
    }
}