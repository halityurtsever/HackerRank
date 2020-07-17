using CodeHelpers;
using System;
using System.Collections.Generic;

namespace QueueTwoStacks
{
    public class Program_QueueTwoStacks
    {
        public static void Main(string[] args)
        {
            var console = new ConsoleWrapper();
            var inputCount = Convert.ToInt32(console.ReadLine());

            ExecuteTask(console, inputCount);
        }

        public static void ExecuteTask(IConsole console, int inputCount)
        {
            var list = new List<string>();

            for (int i = 0; i < inputCount; i++)
            {
                var inputs = console.ReadLine().Split(' ');

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
                    console.WriteLine(list[0]);
                }
            }
        }
    }
}
