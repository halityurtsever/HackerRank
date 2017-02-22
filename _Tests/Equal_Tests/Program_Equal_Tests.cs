using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using CodeHelpers;
using TestHelper;

namespace HackerRank.Tracks.Algorithms.DynamicProgramming.Equal.Tests
{
    [TestClass()]
    public class Program_Equal_Tests : TestBase
    {
        //################################################################################
        #region Tests

        [TestMethod()]
        public void ExecuteTest_1()
        {
            TestRunner("input_1.txt", "output_1.txt");
        }

        [TestMethod()]
        public void ExecuteTest_2()
        {
            TestRunner("input_2.txt", "output_2.txt");
        }

        [TestMethod()]
        public void ExecuteTest_3()
        {
            TestRunner("input_3.txt", "output_3.txt");
        }

        [TestMethod()]
        public void ExecuteTest_4()
        {
            TestRunner("input_4.txt", "output_4.txt");
        }

        [TestMethod()]
        public void ExecuteTest_5()
        {
            TestRunner("input_5.txt", "output_5.txt");
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

            var consoleWrapper = (ConsoleWrapperTest) console;

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