using SudokuSolver.Library;

using NUnit.Framework;

using CodeHelpers;

namespace SudokuSolver_Tests
{
    [TestFixture]
    public class SudokuSolver_Tests : TestBase
    {
        //################################################################################
        #region Tests

        [Test]
        public void TestCase_01()
        {
            TestRunner<Sudoku>("input_01.txt", "output_01.txt");
        }

        #endregion
    }
}
