using System;
using System.Collections.Generic;
using System.IO;

namespace CodeHelpers
{
    public class ConsoleWrapper : IConsole
    {
        //################################################################################
        #region Fields

        //Folder path of test input/output files
        private readonly string m_FolderPath;

        //Test input file
        private int m_CurrentInputIndex;
        private readonly string m_InputFileName;
        private readonly List<string> m_InputData = new List<string>();

        //Test output file
        private int m_CurrentExpectedOutputIndex;
        private int m_CurrentActualOutputIndex;
        private readonly string m_OutputFileName;

        #endregion

        //################################################################################
        #region Constructor

        public ConsoleWrapper(string folderPath, string inputFileName, string outputFileName)
        {
            m_FolderPath = folderPath;
            m_InputFileName = inputFileName;
            m_OutputFileName = outputFileName;
            Initialize();
        }

        #endregion

        //################################################################################
        #region Properties

        public List<string> ExpectedOutput { get; } = new List<string>();

        public List<string> ActualOutput { get; } = new List<string>();

        #endregion


        //################################################################################
        #region IConsole Members

        bool IConsole.ReadLineFromExpectedOutput(out string expectedValue)
        {
            try
            {
                expectedValue = $"{ExpectedOutput[m_CurrentExpectedOutputIndex]}";
                m_CurrentExpectedOutputIndex++;

                return ExpectedOutput.Count > m_CurrentExpectedOutputIndex;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured during reading expected output: {ex.Message}");
                throw;
            }
        }

        bool IConsole.ReadLineFromActualOutput(out string actualValue)
        {
            try
            {
                actualValue = $"{ActualOutput[m_CurrentActualOutputIndex]}";
                m_CurrentActualOutputIndex++;

                return ActualOutput.Count > m_CurrentActualOutputIndex;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured during reading actual output: {ex.Message}");
                throw;
            }
        }

        public string ReadLine()
        {
            try
            {
                var inputData = m_InputData[m_CurrentInputIndex];
                m_CurrentInputIndex++;
                return inputData;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured during input data reading: {ex.Message}");
                throw;
            }
        }

        public void Write(string value)
        {
            ActualOutput.Add($"{value}");
        }

        public void Write(int value)
        {
            ActualOutput.Add($"{value}");
        }

        public void Write(long value)
        {
            ActualOutput.Add($"{value}");
        }

        public void Write(double value)
        {
            ActualOutput.Add($"{value}");
        }

        public void Write(float value)
        {
            ActualOutput.Add($"{value}");
        }

        public void WriteLine(string value)
        {
            ActualOutput.Add($"{value}");
        }

        public void WriteLine(int value)
        {
            ActualOutput.Add($"{value}");
        }

        public void WriteLine(long value)
        {
            ActualOutput.Add($"{value}");
        }

        public void WriteLine(double value)
        {
            ActualOutput.Add($"{value}");
        }

        public void WriteLine(float value)
        {
            ActualOutput.Add($"{value}");
        }

        #endregion

        //################################################################################
        #region Private Members

        private void Initialize()
        {
            //Read input file to input data list
            using (var stream = new StreamReader(Path.Combine(m_FolderPath, m_InputFileName)))
            {
                while (!stream.EndOfStream)
                {
                    m_InputData.Add(stream.ReadLine());
                }
            }

            //Read output file to output data list
            using (var stream = new StreamReader(Path.Combine(m_FolderPath, m_OutputFileName)))
            {
                while (!stream.EndOfStream)
                {
                    ExpectedOutput.Add(stream.ReadLine());
                }
            }
        }

        #endregion
    }
}
