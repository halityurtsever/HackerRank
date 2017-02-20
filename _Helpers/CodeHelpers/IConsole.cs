namespace CodeHelpers
{
    public interface IConsole
    {
        //################################################################################
        #region Console ReadLine

        string ReadLine();

        #endregion

        //################################################################################
        #region Console Write

        void Write(string value);

        void Write(int value);

        void Write(long value);

        void Write(double value);

        void Write(float value);

        #endregion

        //################################################################################
        #region Console WriteLine

        void WriteLine(string value);

        void WriteLine(int value);

        void WriteLine(long value);

        void WriteLine(double value);

        void WriteLine(float value);

        #endregion
    }
}
