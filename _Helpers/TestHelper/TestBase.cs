using CodeHelpers;
using System;
using System.IO;

namespace TestHelper
{
    public abstract class TestBase
    {
        //################################################################################
        #region Fields

        protected string s_InputOutputFolder = "InputsOutputs";

        #endregion

        //################################################################################
        #region Abstract Members

        protected abstract void TestRunner(string inputFile, string outputFile);

        #endregion

        //################################################################################
        #region Protected Members

        protected IConsole GetConsoleReader(string inputFileName, string outputFileName)
        {
            var folderPath = new DirectoryInfo(Environment.CurrentDirectory).FullName;
            return new ConsoleWrapperTest(folderPath, $"{s_InputOutputFolder}/{inputFileName}", $"{s_InputOutputFolder}/{outputFileName}");
        }

        #endregion
    }
}
