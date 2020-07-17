using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver;
using TestHelper;

namespace SudokuSolver_Tests
{
    [TestClass]
    public class Program_SudokuSolver_Tests : TestBase
    {
        //################################################################################
        #region Tests

        [TestMethod()]
        public void SudokuSolver_TestCase_01()
        {
            TestRunner("input_01.txt", "output_01.txt");
        }

        #endregion

        //################################################################################
        #region Private Implementation

        protected override void TestRunner(string inputFile, string outputFile)
        {
            var console = GetConsoleReader(inputFile, outputFile);

            var caseCount = int.Parse(console.ReadLine());
            Program_SudokuSolver.ExecuteTask(console, caseCount);

            
            for (int i = 0; i < caseCount; i++)
            {
                string expectedValue = string.Empty;

                for (int j = 0; j < 9; j++)
                {
                    expectedValue += ((IConsoleTest)console).ReadLineFromExpectedOutput() + "\r\n";
                }

                var actualMaxValue = ((IConsoleTest)console).ReadLineFromActualOutput();

                Assert.AreEqual(expectedValue, actualMaxValue);
            }
        }

        #endregion
    }
}
