using CodeHelpers;

using System.Collections.Generic;

namespace QueueTwoStacks.Library
{
    public class TwoStacksQueuer : ProblemSolverBase, IProblemSolver
    {
        //################################################################################
        #region IProblemSolver Members

        public void Solve(IConsole console)
        {
            Console = console;
            var inputCount = int.Parse(Console.ReadLine());

            QueueStacks(inputCount);
        }

        #endregion

        //################################################################################
        #region Private Members

        private void QueueStacks(int inputCount)
        {
            var list = new List<string>();

            for (int i = 0; i < inputCount; i++)
            {
                var inputs = Console.ReadLine().Split(' ');

                if (inputs[0] == "1")
                {
                    list.Add(inputs[1]);
                    continue;
                }

                if (inputs[0] == "2")
                {
                    list.RemoveAt(0);
                    continue;
                }

                if (inputs[0] == "3")
                {
                    Console.WriteLine(list[0]);
                }
            }
        }

        #endregion
    }
}
