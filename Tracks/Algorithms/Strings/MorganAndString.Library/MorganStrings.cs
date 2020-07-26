using CodeHelpers;
using System.Diagnostics;
using System.Text;

namespace MorganAndString.Library
{
    public class MorganStrings : ProblemSolverBase, IProblemSolver
    {
        //################################################################################
        #region Fields

        private int _sameCharsCount = 1;

        #endregion

        //################################################################################
        #region IProblemSolver Members

        void IProblemSolver.Solve(IConsole console)
        {
            Console = console;

            ReadStringData(int.Parse(Console.ReadLine()));
        }

        #endregion

        //################################################################################
        #region Private Members

        private void ReadStringData(int caseCount)
        {
            for (int i = 0; i < caseCount; i++)
            {
                var jackString = Console.ReadLine();
                var danielString = Console.ReadLine();

                CreateMorganString(jackString, danielString);
            }
        }

        private void CreateMorganString(string jack, string daniel)
        {
            var morganString = new StringBuilder();

            var jackIndex = 0;
            var danielIndex = 0;
            var jackLen = jack.Length;
            var danielLen = daniel.Length;

            for (int i = 0; i < jackLen + danielLen; i++)
            {
                // both indexes are in bound of limits
                if (jackIndex < jackLen && danielIndex < danielLen)
                {
                    // jack is smaller
                    if (jack[jackIndex] < daniel[danielIndex])
                    {
                        morganString.Append(jack[jackIndex]);
                        jackIndex++;
                    }
                    // daniel is smaller
                    else if (jack[jackIndex] > daniel[danielIndex])
                    {
                        morganString.Append(daniel[danielIndex]);
                        danielIndex++;
                    }
                    // they are equal
                    else
                    {
                        if (EqualityState(jack, daniel, jackIndex, danielIndex))
                        {
                            for (int j = 0; j < _sameCharsCount; j++)
                            {
                                morganString.Append(jack[jackIndex]);
                                jackIndex++;
                            }
                        }
                        else
                        {
                            for (int d = 0; d < _sameCharsCount; d++)
                            {
                                morganString.Append(daniel[danielIndex]);
                                danielIndex++;
                            }
                        }

                        _sameCharsCount = 1;
                    }
                }
                // jack index is out of limit, append all remainings of daniel
                else if (jackIndex >= jackLen && danielIndex < danielLen)
                {
                    AppendRemainings(morganString, daniel, danielIndex);
                    break;
                }
                // daniel index is out of limit, append all remainings of jack
                else if (danielIndex >= danielLen && jackIndex < jackLen)
                {
                    AppendRemainings(morganString, jack, jackIndex);
                    break;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(morganString.ToString());
        }

        //8194
        //Expected: "...MNMMNNMMNMNNMNMMNMNNMMNNMNMMNN M MNMNNMMNNMNMMNMNNMNMMNNMMNM..."
        //But was:  "...MNMMNNMMNMNNMNMMNMNNMMNNMNMMNN N MNMMNNMMNMNNMNMMNMNNMMNNMNM..."

        //4097
        //Expected: "...ZYZZYYZZYZYYZ YZZYZYYZZYYZYZZYZ Y YZYZZYYZZYZYYZYZZYZYYZZYYZY..."
        //But was:  "...ZYZZYYZZYZYYZ YZZYZYYZZYYZYZZYZ Z YZYYZZYYZYZZYZYYZYZZYYZZYZY..."

        private bool EqualityState(string jack, string daniel, int jackIndex, int danielIndex)
        {
            if (jackIndex + 1 == jack.Length) return false;
            if (danielIndex + 1 == daniel.Length) return true;

            while (IsCurrentEqualsToNext(jack, daniel, jackIndex, danielIndex) ||
                IsCurrentBiggerThanNext(jack, daniel, jackIndex, danielIndex))
            {
                _sameCharsCount++;
                jackIndex++;
                danielIndex++;

                if (jackIndex + 1 == jack.Length) return false;
                if (danielIndex + 1 == daniel.Length) return true;
            }

            return jack[jackIndex + 1] <= daniel[danielIndex + 1];
        }

        private bool IsCurrentEqualsToNext(string jack, string daniel, int jackIndex, int danielIndex)
        {
            return jack[jackIndex] == jack[jackIndex + 1] &&
                   daniel[danielIndex] == daniel[danielIndex + 1];
        }

        private bool IsCurrentBiggerThanNext(string jack, string daniel, int jackIndex, int danielIndex)
        {
            return jack[jackIndex] > jack[jackIndex + 1] &&
                   daniel[danielIndex] > daniel[danielIndex + 1] &&
                   jack[jackIndex + 1] == daniel[danielIndex + 1];
        }

        private void AppendRemainings(StringBuilder stringBuilder, string source, int startIndex)
        {
            for (int i = startIndex; i < source.Length; i++)
            {
                stringBuilder.Append(source[i]);
            }
        }

        #endregion
    }
}
