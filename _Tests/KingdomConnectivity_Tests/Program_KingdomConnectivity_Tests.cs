using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using CodeHelpers;
using TestHelper;

namespace HackerRank.Tracks.Algorithms.GraphTheory.KingdomConnectivity.Tests
{
    [TestClass()]
    public class Program_KingdomConnectivity_Tests : TestBase
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

        [TestMethod()]
        public void ExecuteTest_6()
        {
            TestRunner("input_6.txt", "output_6.txt");
        }

        [TestMethod()]
        public void ExecuteTest_7()
        {
            TestRunner("input_7.txt", "output_7.txt");
        }

        [TestMethod()]
        public void ExecuteTest_8()
        {
            TestRunner("input_8.txt", "output_8.txt");
        }

        [TestMethod()]
        public void ExecuteTest_9()
        {
            TestRunner("input_9.txt", "output_9.txt");
        }

        [TestMethod()]
        public void ExecuteTest_10()
        {
            TestRunner("input_10.txt", "output_10.txt");
        }

        [TestMethod()]
        public void ExecuteTest_11()
        {
            TestRunner("input_11.txt", "output_11.txt");
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
            //initiate dictionary for new execution
            Program_KingdomConnectivity.CleanUp();

            var directoryInfo = new DirectoryInfo(Environment.CurrentDirectory);
            var console = GetConsoleReader(directoryInfo, $"{s_InputOutputFolder}/{inputFile}", $"{s_InputOutputFolder}/{outputFile}");

            var initials = console.ReadLine().Split(' ');
            var cityCount = Convert.ToInt32(initials[0]);
            var connectionCount = Convert.ToInt32(initials[1]);

            Program_KingdomConnectivity.ExecuteTask(console, cityCount, connectionCount);

            string expectedMaxValue = ((IConsoleTest)console).ReadLineFromExpectedOutput();
            string actualMaxValue = ((IConsoleTest)console).ReadLineFromActualOutput();

            Assert.AreEqual(expectedMaxValue, actualMaxValue);
        }

        #endregion
    }
}