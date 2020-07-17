﻿using CodeHelpers;
using System;
using System.IO;
using System.Reflection;

namespace TestHelper
{
    public abstract class TestBase<T> where T : IProblemSolver
    {
        //################################################################################
        #region Fields

        protected string s_InputOutputFolder = "InputsOutputs";

        #endregion

        protected IProblemSolver ProblemSolver { get; set; }

        protected string ActualValue { get; private set; }

        protected string ExpectedValue { get; private set; }

        //################################################################################
        #region Abstract Members

        //protected abstract void TestRunner(string inputFile, string outputFile);

        #endregion

        //################################################################################
        #region Protected Members

        protected IConsole GetConsoleReader(string inputFileName, string outputFileName)
        {
            var folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ConsoleWrapper(folderPath, $"{s_InputOutputFolder}/{inputFileName}", $"{s_InputOutputFolder}/{outputFileName}");
        }

        #endregion

        protected void TestRunner(string inputFile, string outputFile)
        {
            IConsole console = GetConsoleReader(inputFile, outputFile);
            ProblemSolver.Solve(console);

            ActualValue = console.ReadLineFromActualOutput();
            ExpectedValue = console.ReadLineFromExpectedOutput();
        }
    }
}
