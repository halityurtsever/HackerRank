using CodeHelpers;

using System.Collections.Generic;
using System.Text;

namespace SudokuSolver.Library
{
    public class Sudoku : ProblemSolverBase, IProblemSolver
    {
        //################################################################################
        #region Private Struct

        private struct Point
        {
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; set; }

            public int Y { get; set; }
        }

        #endregion

        //################################################################################
        #region IProblemSolver Members

        public void Solve(IConsole console)
        {
            Console = console;
            var caseCount = int.Parse(Console.ReadLine());

            int[,] sudokuPad = new int[9, 9];

            for (int i = 0; i < caseCount; i++)
            {
                CreateSudokuPad(sudokuPad);
                SolvePuzzle(sudokuPad);
                sudokuPad = new int[9, 9];
            }
        }

        #endregion

        //################################################################################
        #region Private Members

        private void SolvePuzzle(int[,] sudokuPad)
        {
            while (!IsSolved(sudokuPad))
            {
                SolveWithElaminateStrategy(sudokuPad);
                SolveWithSectionComparisonStrategy(sudokuPad);
            }

            PrintSudokuPad(sudokuPad);
        }

        private void SolveWithElaminateStrategy(int[,] pad)
        {
            IList<int> sudokuNumbers = null;
            RefillSudokuNumbers(ref sudokuNumbers);

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (pad[i, j] == 0)
                    {
                        RefillSudokuNumbers(ref sudokuNumbers);

                        CheckRow(pad, i, sudokuNumbers);
                        CheckColumn(pad, j, sudokuNumbers);
                        CheckSection(pad, GetSectionIndex(i, j), sudokuNumbers);

                        if (sudokuNumbers.Count == 1)
                        {
                            pad[i, j] = sudokuNumbers[0];
                        }
                    }
                }
            }
        }

        private void SolveWithSectionComparisonStrategy(int[,] pad)
        {
            int x = 0, y = 0;
            var possibleNumbers = new Dictionary<int, IList<Point>>();
            var emptyPoints = new List<Point>();

            //traverse pad
            for (int i = 0; i < 9; i++)
            {
                possibleNumbers.Clear();
                emptyPoints.Clear();

                for (int n = 0; n < 9; n++)
                {
                    possibleNumbers.Add(n + 1, new List<Point>());
                }

                //traverse section
                for (int j = 0; j < 9; j++)
                {
                    x = (3 * (i / 3)) + (j / 3);
                    y = (3 * (i % 3)) + (j % 3);

                    if (pad[x, y] != 0)
                    {
                        possibleNumbers.Remove(pad[x, y]);
                    }
                    else
                    {
                        emptyPoints.Add(new Point(x, y));
                    }
                }

                foreach (var number in possibleNumbers)
                {
                    foreach (var point in emptyPoints)
                    {
                        if (IsPossible(pad, number.Key, point))
                        {
                            number.Value.Add(point);
                        }
                    }

                    if (number.Value.Count == 1)
                    {
                        var point = number.Value[0];
                        pad[point.X, point.Y] = number.Key;
                    }
                }
            }
        }

        private bool IsPossible(int[,] pad, int number, Point point)
        {
            for (int i = 0; i < 9; i++)
            {
                if (pad[point.X, i] == number || pad[i, point.Y] == number)
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsSolved(int[,] pad)
        {
            var isSolved = true;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (pad[i, j] == 0)
                    {
                        isSolved = false;
                        break;
                    }

                    if (!isSolved) break;
                }
            }

            return isSolved;
        }

        private void CheckRow(int[,] pad, int rowIndex, IList<int> numbers)
        {
            for (int i = 0; i < 9; i++)
            {
                if (numbers.Contains(pad[rowIndex, i]))
                {
                    numbers.Remove(pad[rowIndex, i]);
                }
            }
        }

        private void CheckColumn(int[,] pad, int columnIndex, IList<int> numbers)
        {
            for (int i = 0; i < 9; i++)
            {
                if (numbers.Contains(pad[i, columnIndex]))
                {
                    numbers.Remove(pad[i, columnIndex]);
                }
            }
        }

        private void CheckSection(int[,] pad, Point sectionIndex, IList<int> numbers)
        {
            var x = sectionIndex.X;
            var y = sectionIndex.Y;

            for (int i = 0; i < 3; i++)
            {
                x = sectionIndex.X + i % 3;

                for (int j = 0; j < 3; j++)
                {
                    y = sectionIndex.Y + j % 3;

                    if (numbers.Contains(pad[x, y]))
                    {
                        numbers.Remove(pad[x, y]);
                    }
                }
            }
        }

        private Point GetSectionIndex(int i, int j)
        {
            var x = i - (i % 3);
            var y = j - (j % 3);

            return new Point(x, y);
        }

        private void RefillSudokuNumbers(ref IList<int> numbers)
        {
            numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        }

        private void CreateSudokuPad(int[,] sudokuPad)
        {
            for (int i = 0; i < 9; i++)
            {
                var numbers = Console.ReadLine().Split(' ');

                for (int j = 0; j < 9; j++)
                {
                    sudokuPad[i, j] = int.Parse(numbers[j]);
                }
            }
        }

        private void PrintSudokuPad(int[,] pad)
        {
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < 9; i++)
            {
                stringBuilder.Clear();

                for (int j = 0; j < 9; j++)
                {
                    stringBuilder.Append($"{pad[i, j]} ");

                }

                Console.WriteLine(stringBuilder.ToString());
            }
        }

        #endregion
    }
}
