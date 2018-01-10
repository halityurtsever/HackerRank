using CodeHelpers;

namespace TestHelper
{
    public interface IConsoleOutputReader : IConsole
    {
        string ReadLineFromExpectedOutput();

        string ReadLineFromActualOutput();
    }
}
