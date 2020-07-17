using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QueueTwoStacks;
using TestHelper;

namespace QueueTwoStacks_Tests
{
    [TestClass]
    public class Program_QueueTwoStacks_Tests : TestBase
    {
        //################################################################################
        #region Tests

        [TestMethod()]
        public void QueueTwoStacks_TestCase_01()
        {
            TestRunner("input_01.txt", "output_01.txt");
        }

        [TestMethod()]
        public void QueueTwoStacks_TestCase_02()
        {
            TestRunner("input_02.txt", "output_02.txt");
        }

        #endregion

        //################################################################################
        #region Private Implementation

        protected override void TestRunner(string inputFile, string outputFile)
        {
            var console = GetConsoleReader(inputFile, outputFile);

            var inputCount = Convert.ToInt32(console.ReadLine());

            Program_QueueTwoStacks.ExecuteTask(console, inputCount);

            long expectedMaxValue = Convert.ToInt64(((IConsoleTest)console).ReadLineFromExpectedOutput());
            long actualMaxValue = Convert.ToInt64(((IConsoleTest)console).ReadLineFromActualOutput());

            Assert.AreEqual(expectedMaxValue, actualMaxValue);
        }

        #endregion
    }
}
