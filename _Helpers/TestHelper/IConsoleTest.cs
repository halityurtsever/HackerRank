using CodeHelpers;

namespace TestHelper
{
    public interface IConsoleTest : IConsole
    {
        string ReadLineFromExpectedOutput();

        string ReadLineFromActualOutput();
    }
}
