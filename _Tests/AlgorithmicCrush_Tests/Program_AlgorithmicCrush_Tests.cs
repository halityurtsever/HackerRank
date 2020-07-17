using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestHelper;

namespace HackerRank.Tracks.DataStructures.Arrays.AlgorithmicCrush.Tests
{
    [TestClass()]
    public class Program_AlgorithmicCrush_Tests : TestBase
    {
        //################################################################################
        #region Tests

        [TestMethod()]
        public void AlgorithmicCrush_TestCase_01()
        {
            TestRunner("input_1.txt", "output_1.txt");
        }

        [TestMethod()]
        public void AlgorithmicCrush_TestCase_02()
        {
            TestRunner("input_2.txt", "output_2.txt");
        }

        [TestMethod()]
        public void AlgorithmicCrush_TestCase_03()
        {
            TestRunner("input_3.txt", "output_3.txt");
        }

        #endregion

        //################################################################################
        #region Private Implementation

        protected override void TestRunner(string inputFile, string outputFile)
        {
            var console = GetConsoleReader(inputFile, outputFile);

            var initialValues = console.ReadLine().Split(' ');
            var arraySize = Convert.ToInt32(initialValues[0]);
            var querySize = Convert.ToInt32(initialValues[1]);

            Program_AlgorithmicCrush.ExecuteTask(console, arraySize, querySize);

            long expectedMaxValue = Convert.ToInt64(((IConsoleTest)console).ReadLineFromExpectedOutput());
            long actualMaxValue = Convert.ToInt64(((IConsoleTest)console).ReadLineFromActualOutput());

            Assert.AreEqual(expectedMaxValue, actualMaxValue);
        }

        #endregion
    }
}