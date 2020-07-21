using CodeHelpers;

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrosswordPuzzle.Library
{
    public class CrosswordSolver : ProblemSolverBase, IProblemSolver
    {
        //################################################################################
        #region Fields

        private readonly char EmptyCell = '-';
        private readonly char BlockCell = '+';

        private char[,] _puzzleMatrix;
        private IList<string> _wordList;
        private IList<Point> _emptyCellList;
        private IList<IEnumerable<Point>> _wordCellLists;

        #endregion

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
            _wordList = new List<string>();
            _puzzleMatrix = new char[10, 10];
            _emptyCellList = new List<Point>();
            _wordCellLists = new List<IEnumerable<Point>>();

            Console = console;

            FillPuzzleMatrix(ReadPuzzleData());
            CollectWordCellLists();
            MatchWordsWithEmptyCellLists();
            PrintCrossword();
        }

        #endregion

        //################################################################################
        #region Private Members

        private string[] ReadPuzzleData()
        {
            string[] crossword = new string[10];

            for (int i = 0; i < 10; i++)
            {
                string crosswordItem = Console.ReadLine();
                crossword[i] = crosswordItem;
            }

            ParseWords(Console.ReadLine());

            return crossword;
        }

        private void ParseWords(string input)
        {
            foreach (var item in input.Split(';'))
            {
                _wordList.Add(item);
            }
        }

        private void FillPuzzleMatrix(string[] crossword)
        {
            for (int x = 0; x < crossword.Length; x++)
            {
                for (int i = 0; i < 10; i++)
                {
                    _puzzleMatrix[x, i] = crossword[x][i];

                    if (crossword[x][i] == EmptyCell)
                    {
                        _emptyCellList.Add(new Point(x, i));
                    }
                }
            }
        }

        private void CollectWordCellLists()
        {
            bool? isDown = null;

            foreach (var point in _emptyCellList)
            {
                isDown = null;


                if (point.X - 1 == -1 || _puzzleMatrix[point.X - 1, point.Y] == BlockCell)
                {
                    if (point.X + 1 < 10 && _puzzleMatrix[point.X + 1, point.Y] == EmptyCell)
                    {
                        isDown = true;
                    }
                }
                
                if (point.Y - 1 == -1 || _puzzleMatrix[point.X, point.Y - 1] == BlockCell)
                {
                    if (point.Y + 1 < 10 && _puzzleMatrix[point.X, point.Y + 1] == EmptyCell)
                    {
                        isDown = false;
                    }
                }

                if (isDown != null)
                {
                    _wordCellLists.Add(GetWordCellList(point, isDown));
                }
            }
        }

        private IEnumerable<Point> GetWordCellList(Point startPoint, bool? isDown)
        {
            var wordCellList = new List<Point>();

            while (_puzzleMatrix[startPoint.X, startPoint.Y] != BlockCell)
            {
                wordCellList.Add(startPoint);

                if (isDown == true)
                {
                    startPoint.X++;
                }
                else
                {
                    startPoint.Y++;
                }

                if (startPoint.X > 9 || startPoint.Y > 9) break;
            }

            return wordCellList;
        }

        private void MatchWordsWithEmptyCellLists()
        {
            MatchUniqueLenghtWords();

            while (_wordCellLists.Count > 0)
            {
                var wordListsToRemove = new List<IEnumerable<Point>>();
                foreach (var wordCellList in _wordCellLists)
                {
                    var index = 0;
                    var word = string.Empty;

                    foreach (var cell in wordCellList)
                    {
                        var currentChar = _puzzleMatrix[cell.X, cell.Y];
                        if (currentChar != EmptyCell)
                        {
                            word = GetPossibleWordIfAny(currentChar, index, wordCellList.Count());
                            if (!string.IsNullOrEmpty(word)) break;
                        }

                        index++;
                    }

                    if (!string.IsNullOrEmpty(word))
                    {
                        PlaceWordToEmptyCells(word, wordCellList, false);
                        wordListsToRemove.Add(wordCellList);
                    }
                }

                foreach (var wordList in wordListsToRemove)
                {
                    _wordCellLists.Remove(wordList);
                }
            }
        }

        private string GetPossibleWordIfAny(char c, int index, int wordLength)
        {
            foreach (var word in _wordList)
            {
                if (index >= word.Length) continue;
                if (word.Length != wordLength) continue;

                if (word[index] == c)
                {
                    return word;
                }
            }

            return string.Empty;
        }

        private void MatchUniqueLenghtWords()
        {
            var uniqueLengthWords = _wordList.GroupBy(x => x.Length).OrderByDescending(y => y.Key).Where(z => z.Count() == 1).GetEnumerator();
            var uniqueLenghtWordCellLists = _wordCellLists.GroupBy(x => x.Count()).OrderByDescending(y => y.Key).Where(z => z.Count() == 1).GetEnumerator();

            var isLoop = true;
            while (isLoop)
            {
                isLoop = uniqueLengthWords.MoveNext();
                isLoop = uniqueLenghtWordCellLists.MoveNext();

                if (isLoop)
                {
                    PlaceWordToEmptyCells(uniqueLengthWords.Current.First(), uniqueLenghtWordCellLists.Current.First(), true);
                }
            }
        }

        private void PlaceWordToEmptyCells(string word, IEnumerable<Point> emptyCells, bool removeWordList)
        {
            if (emptyCells.Count() != word.Length) return;

            var index = 0;
            foreach (var cell in emptyCells)
            {
                _puzzleMatrix[cell.X, cell.Y] = word[index];

                index++;
            }

            _wordList.Remove(word);
            if (removeWordList) _wordCellLists.Remove(emptyCells);
        }

        private void PrintCrossword()
        {
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    stringBuilder.Append($"{_puzzleMatrix[i, j]}");
                }

                Console.WriteLine(stringBuilder.ToString());
                stringBuilder.Clear();
            }
        }

        #endregion
    }
}
