using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestHelper;

namespace HackerRank.Tutorials._30DaysOfCode.BitwiseAND.Tests
{
    [TestClass()]
    public class Program_BitwiseAND_Tests : TestBase
    {
        //################################################################################
        #region Tests

        [TestMethod()]
        public void BitwiseAND_TestCase_01()
        {
            TestRunner("input_1.txt", "output_1.txt");
        }

        #endregion

        //################################################################################
        #region Private Implementation

        protected override void TestRunner(string inputFile, string outputFile)
        {
            var console = GetConsoleReader(inputFile, outputFile);

            Program_BitwiseAND.ExecuteTask(console);

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