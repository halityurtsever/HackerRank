using CodeHelpers;
using System.IO;

namespace TestHelper
{
    public abstract class TestBase
    {
        public abstract IConsole GetConsoleReader(DirectoryInfo directory, string inputFileName, string outputFileName);
    }
}
