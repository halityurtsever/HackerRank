using CodeHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TestHelper;

namespace HackerRank.Tracks.Algorithms.DynamicProgramming.Equal.Tests
{
    [TestClass()]
    public class Program_Equal_Tests : TestBase
    {
        //################################################################################
        #region Tests

        [TestMethod()]
        public void ExecuteTest_01()
        {
            TestRunner("input_1.txt", "output_1.txt");
        }

        [TestMethod()]
        public void ExecuteTest_02()
        {
            TestRunner("input_2.txt", "output_2.txt");
        }

        [TestMethod()]
        public void ExecuteTest_03()
        {
            TestRunner("input_3.txt", "output_3.txt");
        }

        [TestMethod()]
        public void ExecuteTest_04()
        {
            TestRunner("input_4.txt", "output_4.txt");
        }

        [TestMethod()]
        public void ExecuteTest_05()
        {
            TestRunner("input_5.txt", "output_5.txt");
        }

        [TestMethod()]
        public void ExecuteTest_06()
        {
            TestRunner("input_6.txt", "output_6.txt");
        }

        [TestMethod()]
        public void ExecuteTest_07()
        {
            TestRunner("input_7.txt", "output_7.txt");
        }

        [TestMethod()]
        public void ExecuteTest_08()
        {
            TestRunner("input_8.txt", "output_8.txt");
        }

        [TestMethod()]
        public void ExecuteTest_09()
        {
            TestRunner("input_9.txt", "output_9.txt");
        }


        [TestMethod()]
        public void ExecuteTest_10()
        {
            TestRunner("input_10.txt", "output_10.txt");
        }

        #endregion

        //################################################################################
        #region Override Implementation

        public override IConsole GetConsoleReader(DirectoryInfo directory, string inputFileName, string outputFileName)
        {
            var folderPath = directory.Parent.Parent.FullName;
            return new ConsoleWrapperTest(folderPath, inputFileName, outputFileName);
        }

        #endregion

        //################################################################################
        #region Private Implementation

        private void TestRunner(string inputFile, string outputFile)
        {
            var directoryInfo = new DirectoryInfo(Environment.CurrentDirectory);
            var console = GetConsoleReader(directoryInfo, $"{s_InputOutputFolder}/{inputFile}", $"{s_InputOutputFolder}/{outputFile}");

            Program_Equal.ExecuteTask(console);

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