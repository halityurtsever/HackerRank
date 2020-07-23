using NUnit.Framework;

using System.IO;
using System.Reflection;

namespace CodeHelpers
{
    [TestFixture]
    public abstract class TestBase
    {
        //################################################################################
        #region Fields

        protected string s_InputOutputFolder = "InputsOutputs";

        #endregion

        //################################################################################
        #region Protected Members

        protected string ActualValue { get; private set; }

        protected string ExpectedValue { get; private set; }

        protected IConsole GetConsoleReader(string inputFileName, string outputFileName)
        {
            var folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ConsoleWrapper(folderPath, $"{s_InputOutputFolder}/{inputFileName}", $"{s_InputOutputFolder}/{outputFileName}");
        }

        protected void TestRunner<T>(string inputFile, string outputFile) where T : IProblemSolver, new()
        {
            IConsole console = GetConsoleReader(inputFile, outputFile);
            IProblemSolver solver = new T();
            solver.Solve(console);

            var hasExpected = true;
            var hasActual = true;
            var actualValue = string.Empty;
            var expectedValue = string.Empty;

            while (hasActual && hasExpected)
            {
                hasActual = console.ReadLineFromActualOutput(out actualValue);
                hasExpected = console.ReadLineFromExpectedOutput(out expectedValue);

                Assert.That(expectedValue, Is.EqualTo(actualValue));
            }
        }

        #endregion
    }
}
