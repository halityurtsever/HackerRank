using System;

namespace CodeHelpers
{
    public class ConsoleWrapper : IConsole
    {
        //################################################################################
        #region Console ReadLine

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        #endregion

        //################################################################################
        #region Console Write

        public void Write(long value)
        {
            Console.Write(value);
        }

        public void Write(float value)
        {
            Console.Write(value);
        }

        public void Write(double value)
        {
            Console.Write(value);
        }

        public void Write(int value)
        {
            Console.Write(value);
        }

        public void Write(string value)
        {
            Console.Write(value);
        }

        #endregion

        //################################################################################
        #region Console WriteLine

        public void WriteLine(double value)
        {
            Console.WriteLine(value);
        }

        public void WriteLine(float value)
        {
            Console.WriteLine(value);
        }

        public void WriteLine(long value)
        {
            Console.WriteLine(value);
        }

        public void WriteLine(int value)
        {
            Console.WriteLine(value);
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }

        #endregion
    }
}
