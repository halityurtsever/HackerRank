using CodeHelpers;
using System.Text;

namespace MorganAndString.Library
{
    public class MorganStrings : ProblemSolverBase, IProblemSolver
    {
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

        private void CreateMorganString(string jackString, string danielString)
        {
            var morganString = new StringBuilder();
            var charCount = jackString.Length + danielString.Length;
            int jackIndex = 0, danielIndex = 0;

            for (int i = 0; i < charCount; i++)
            {
                if (jackIndex >= jackString.Length ||
                    (danielIndex < danielString.Length && jackString[jackIndex] > danielString[danielIndex]))
                {
                    morganString.Append(danielString[danielIndex]);
                    danielIndex++;
                    continue;
                }

                if (danielIndex >= danielString.Length ||
                    (jackIndex < jackString.Length && jackString[jackIndex] < danielString[danielIndex]))
                {
                    morganString.Append(jackString[jackIndex]);
                    jackIndex++;
                    continue;
                }

                if (jackIndex < jackString.Length &&
                    danielIndex < danielString.Length &&
                    jackString[jackIndex] == danielString[danielIndex])
                {
                    var tempJackIndex = jackIndex;
                    var tempDanielIndex = danielIndex;

                    while (true)
                    {
                        if (tempJackIndex < jackString.Length &&
                            tempDanielIndex < danielString.Length)
                        {
                            if (jackString[tempJackIndex] > danielString[tempDanielIndex])
                            {
                                morganString.Append(danielString[danielIndex]);
                                danielIndex++;
                                break;
                            }
                            else if (jackString[tempJackIndex] < danielString[tempDanielIndex])
                            {
                                morganString.Append(jackString[jackIndex]);
                                jackIndex++;
                                break;
                            }
                            else
                            {
                                tempJackIndex++;
                                tempDanielIndex++;

                                continue;
                            }
                        }
                        else if (tempJackIndex >= jackString.Length &&
                            tempDanielIndex < danielString.Length)
                        {
                            morganString.Append(danielString[danielIndex]);
                            danielIndex++;
                            break;
                        }
                        else if (tempJackIndex < jackString.Length &&
                            tempDanielIndex >= danielString.Length)
                        {
                            morganString.Append(jackString[jackIndex]);
                            jackIndex++;
                            break;
                        }
                        else
                        {
                            morganString.Append(jackString[jackIndex]);
                            jackIndex++;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(morganString.ToString());
        }

        #endregion
    }
}
