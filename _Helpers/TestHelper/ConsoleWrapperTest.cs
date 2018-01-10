using System;
using System.Collections.Generic;
using System.IO;

namespace TestHelper
{
    public class ConsoleWrapperTest : IConsoleOutputReader
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
        private readonly List<string> m_OutputDataExpected = new List<string>();
        private readonly List<string> m_OutputDataActual = new List<string>();

        #endregion

        //################################################################################
        #region Constructor

        public ConsoleWrapperTest(string folderPath, string inputFileName, string outputFileName)
        {
            m_FolderPath = folderPath;
            m_InputFileName = inputFileName;
            m_OutputFileName = outputFileName;
            Initialize();
        }

        #endregion

        //################################################################################
        #region Properties

        public List<string> ExpectedOutput => m_OutputDataExpected;

        public List<string> ActualOutput => m_OutputDataActual;

        #endregion

        //################################################################################
        #region Private Implementation

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
                    m_OutputDataExpected.Add(stream.ReadLine());
                }
            }
        }

        #endregion

        //################################################################################
        #region IOutputReader Implementation

        public string ReadLineFromExpectedOutput()
        {
            try
            {
                var outputData = m_OutputDataExpected[m_CurrentExpectedOutputIndex];
                m_CurrentExpectedOutputIndex++;
                return outputData;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured during reading expected output: {ex.Message}");
                throw;
            }
        }

        public string ReadLineFromActualOutput()
        {
            try
            {
                var outputData = m_OutputDataActual[m_CurrentActualOutputIndex];
                m_CurrentActualOutputIndex++;
                return outputData;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured during reading actual output: {ex.Message}");
                throw;
            }
        }

        #endregion

        //################################################################################
        #region IConsole Implementation

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
            m_OutputDataActual.Add($"{value}");
        }

        public void Write(int value)
        {
            m_OutputDataActual.Add($"{value}");
        }

        public void Write(long value)
        {
            m_OutputDataActual.Add($"{value}");
        }

        public void Write(double value)
        {
            m_OutputDataActual.Add($"{value}");
        }

        public void Write(float value)
        {
            m_OutputDataActual.Add($"{value}");
        }

        public void WriteLine(string value)
        {
            m_OutputDataActual.Add($"{value}");
        }

        public void WriteLine(int value)
        {
            m_OutputDataActual.Add($"{value}");
        }

        public void WriteLine(long value)
        {
            m_OutputDataActual.Add($"{value}");
        }

        public void WriteLine(double value)
        {
            m_OutputDataActual.Add($"{value}");
        }

        public void WriteLine(float value)
        {
            m_OutputDataActual.Add($"{value}");
        }

        #endregion
    }
}
