
namespace CodeHelpers
{
    public abstract class ProblemBase
    {
        protected IConsole Console { get; set; } = new ConsoleWrapper();
    }
}
