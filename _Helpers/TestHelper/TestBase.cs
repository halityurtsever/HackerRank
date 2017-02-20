using CodeHelpers;
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
        #region Abstract Methods

        public abstract IConsole GetConsoleReader(DirectoryInfo directory, string inputFileName, string outputFileName);

        #endregion
    }
}
