using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using CodeHelpers;
using TestHelper;

namespace HackerRank.Tracks.Algorithms.Strings.BuildPalindrome.Tests
{
    [TestClass()]
    public class Program_BuildPalindrome_Tests : TestBase
    {
        //################################################################################
        #region Tests

        [TestMethod()]
        public void BuildPalindrome_TestCase_01()
        {
            //Get console reader
            var directoryInfo = new DirectoryInfo(Environment.CurrentDirectory);
            var console = GetConsoleReader(directoryInfo, "input_1.txt", "output_1.txt");

            TestRunner(console);
        }

        [TestMethod()]
        public void BuildPalindrome_TestCase_02()
        {
            //Get console reader
            var directoryInfo = new DirectoryInfo(Environment.CurrentDirectory);
            var console = GetConsoleReader(directoryInfo, "input_2.txt", "output_2.txt");

            TestRunner(console);
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

        private void TestRunner(IConsole console)
        {
            var querySize = Convert.ToInt32(console.ReadLine());

            Program_BuildPalindrome.ExecuteTask(console, querySize);

            var expectedOutput = ((ConsoleWrapperTest)console).ExpectedOutput;
            var actualOutput = ((ConsoleWrapperTest)console).ActualOutput;
            var expectedOutputCount = expectedOutput.Count;
            var actualOutputCount = actualOutput.Count;

            Assert.AreEqual(expectedOutputCount, actualOutputCount);

            for (int i = 0; i < actualOutputCount; i++)
            {
                var expectedData = expectedOutput[i];
                var actualData = actualOutput[i];
                Assert.AreEqual(expectedData, actualData);
            }
        }

        #endregion
    }
}