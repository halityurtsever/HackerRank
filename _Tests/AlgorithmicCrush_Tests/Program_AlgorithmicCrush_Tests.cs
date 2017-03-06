using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using CodeHelpers;
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
        #region Override Implementation

        public override IConsole GetConsoleReader(DirectoryInfo directory, string inputFileName, string outputFileName)
        {
            var folderPath = directory.Parent.Parent.FullName;
            return new ConsoleWrapperTest(folderPath, $"{s_InputOutputFolder}/{inputFileName}", $"{s_InputOutputFolder}/{outputFileName}");
        }

        #endregion

        //################################################################################
        #region Private Implementation

        private void TestRunner(string inputFile, string outputFile)
        {
            var directoryInfo = new DirectoryInfo(Environment.CurrentDirectory);
            var console = GetConsoleReader(directoryInfo, inputFile, outputFile);
            var initialValues = console.ReadLine().Split(' ');
            var arraySize = Convert.ToInt32(initialValues[0]);
            var querySize = Convert.ToInt32(initialValues[1]);

            Program_AlgorithmicCrush.Execute(console, querySize, arraySize);

            long expectedMaxValue = Convert.ToInt64(((IConsoleTest)console).ReadLineFromExpectedOutput());
            long actualMaxValue = Convert.ToInt64(((IConsoleTest)console).ReadLineFromActualOutput());

            Assert.AreEqual(expectedMaxValue, actualMaxValue);
        }

        #endregion
    }
}