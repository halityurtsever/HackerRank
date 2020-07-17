using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TestHelper;

namespace HackerRank.Tracks.Algorithms.Strings.BuildPalindrome.Tests
{
    [TestClass()]
    public class Program_BuildPalindrome_Tests : TestBase
    {
        //################################################################################
        #region Tests

        //[TestMethod()]
        public void BuildPalindrome_TestCase_01()
        {
            //Get console reader
            var directoryInfo = new DirectoryInfo(Environment.CurrentDirectory);
            

            TestRunner("input_1.txt", "output_1.txt");
        }

        //[TestMethod()]
        //public void BuildPalindrome_TestCase_02()
        //{
        //    //Get console reader
        //    var directoryInfo = new DirectoryInfo(Environment.CurrentDirectory);
        //    var console = GetConsoleReader(directoryInfo, "input_2.txt", "output_2.txt");

        //    TestRunner(console);
        //}

        #endregion

        //################################################################################
        #region Private Implementation

        protected override void TestRunner(string inputFile, string outputFile)
        {
            var console = GetConsoleReader(inputFile, outputFile);
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