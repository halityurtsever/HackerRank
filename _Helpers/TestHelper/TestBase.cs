using System;
using System.IO;
using CodeHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestHelper
{
    public abstract class TestBase<T> where T : IProblemSolver, new()
    {
        //################################################################################
        #region Fields

        private const string InputOutputFolder = "InputsOutputs";

        #endregion

        //################################################################################
        #region Protected Implementation

        protected void TestRunner(string inputFile, string outputFile)
        {
            var console = GetConsoleReader(inputFile, outputFile);

            IProblemSolver directConnectionsProblem = new T();
            directConnectionsProblem.Execute(console);

            AssertTestResults(console);
        }

        #endregion

        //################################################################################
        #region Private Implementation

        private IConsoleTest GetConsoleReader(string inputFile, string outputFile)
        {
            var inputFileName = $"{InputOutputFolder}/{inputFile}";
            var outputFileName = $"{InputOutputFolder}/{outputFile}";
            var directory = new DirectoryInfo(Environment.CurrentDirectory);

            var folderPath = directory.Parent?.Parent?.FullName;
            if (string.IsNullOrEmpty(folderPath)) throw new ArgumentNullException(nameof(folderPath));

            return new ConsoleWrapperTest(folderPath, inputFileName, outputFileName);
        }

        private void AssertTestResults(IConsoleTest console)
        {
            var consoleWrapper = console as ConsoleWrapperTest;
            if (consoleWrapper == null) throw new ArgumentNullException(nameof(consoleWrapper));

            Assert.AreEqual(consoleWrapper.ExpectedOutput.Count, consoleWrapper.ActualOutput.Count);

            for (var i = 0; i < consoleWrapper.ActualOutput.Count; i++)
            {
                string expectedMaxValue = console.ReadLineFromExpectedOutput();
                string actualMaxValue = console.ReadLineFromActualOutput();

                Assert.AreEqual(expectedMaxValue, actualMaxValue);
            }
        }

        #endregion
    }
}
