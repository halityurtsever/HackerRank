using CodeHelpers;
using System;
using System.Collections.Generic;

namespace HackerRank.Tracks.Algorithms.Strings.BuildPalindrome
{
    public class Program_BuildPalindrome
    {
        //################################################################################
        #region Fields

        static List<string> palindromes = new List<string>();

        #endregion

        //################################################################################
        #region Main Method

        static void Main(string[] args)
        {
            var console = new ConsoleWrapper();
            var querySize = Convert.ToInt32(Console.ReadLine());

            ExecuteTask(console, querySize);
        }

        #endregion

        //################################################################################
        #region Public Implementation

        public static void ExecuteTask(IConsole console, int querySize)
        {
            for (int q = 0; q < querySize; q++)
            {
                var firstInput = console.ReadLine();
                var secondInput = console.ReadLine();

                PalindromeWord firstWord = new PalindromeWord(firstInput);
                PalindromeWord secondWord = new PalindromeWord(secondInput);

                FindLongestPalindromes(firstWord, secondWord);

                if (palindromes.Count == 0)
                    console.WriteLine("-1");
                else
                    console.WriteLine(GetTheLongestPalindrome());

                palindromes.Clear();
            }
        }

        #endregion

        //################################################################################
        #region Private Implementation

        private static string GetTheLongestPalindrome()
        {
            var theLongest = string.Empty;
            foreach (var palindrome in palindromes)
            {
                if (palindrome.Length < theLongest.Length)
                    continue;

                if (palindrome.Length == theLongest.Length)
                {
                    if (string.Compare(palindrome, theLongest) < 0)
                    {
                        theLongest = palindrome;
                    }
                }

                theLongest = palindrome;
            }
            return theLongest;
        }

        private static void FindLongestPalindromes(PalindromeWord firstWord, PalindromeWord secondWord)
        {
            var firstLastIndex = 0;
            var secondLastIndex = 0;
            FindPalindromeParts(firstWord, secondWord, out firstLastIndex, out secondLastIndex);
            firstWord.ExcludePalindromeAndFindInners();
            secondWord.ExcludePalindromeAndFindInners();

            foreach (var innerPalindrome in firstWord.InnerPalindromes)
            {
                if (firstLastIndex != 0 && innerPalindrome.StartIndex == firstLastIndex)
                {
                    palindromes.Add($"{firstWord.PalindromePart}{innerPalindrome.Palindrome}{secondWord.PalindromePart}");
                }

                /**
                 * TODO: add inner palindromes which are longer than palindromes in the palindromes list
                 */
            }

            foreach (var innerPalindrome in secondWord.InnerPalindromes)
            {
                if (secondLastIndex >= innerPalindrome.Length && innerPalindrome.StartIndex + innerPalindrome.Length == secondLastIndex)
                {
                    palindromes.Add($"{firstWord.PalindromePart}{innerPalindrome.Palindrome}{secondWord.PalindromePart}");
                }
            }

            ConcatPalindromeParts(firstWord, secondWord);
        }

        private static void FindPalindromeParts(PalindromeWord firstWord, PalindromeWord secondWord, out int firstPalindromeLastIndex, out int secondPalindromeLastIndex)
        {
            var temp = string.Empty;
            var first = firstWord.Input;
            var second = secondWord.Reverse;
            var palindromePart = string.Empty;

            var index = 0;
            var length = 1;
            firstPalindromeLastIndex = 0;
            secondPalindromeLastIndex = 0;
            while (true)
            {
                if ((index + length) >= first.Length)
                    break;

                temp = first.Substring(index, length);
                if (second.Contains(temp))
                {
                    if ((temp.Length > palindromePart.Length) ||
                        ((temp.Length == palindromePart.Length) && (string.Compare(temp, palindromePart) < 0)) ||
                        string.IsNullOrEmpty(palindromePart))
                    {
                        palindromePart = temp;
                        firstPalindromeLastIndex = index + palindromePart.Length;
                        temp = string.Empty;
                    }
                    length++;
                    continue;
                }
                index++;
                length = 1;
            }

            firstWord.PalindromePart = palindromePart;
            secondWord.PalindromePart = PalindromeWord.ReverseWord(palindromePart);
            secondPalindromeLastIndex = secondWord.Input.IndexOf(secondWord.PalindromePart);
        }

        private static void ConcatPalindromeParts(PalindromeWord firstWord, PalindromeWord secondWord)
        {
            var firstPart = firstWord.PalindromePart;
            var secondPart = secondWord.PalindromePart;

            var firstPartIndex = firstWord.Input.IndexOf(firstPart);
            var secondPartIndex = secondWord.Input.IndexOf(secondPart);

            //firstpart sonda ve secondpart başta ise => firstpart + secondpart
            if ((firstPartIndex + firstPart.Length >= firstWord.Input.Length) && secondPartIndex == 0)
            {
                var palindromeCandidate = $"{firstPart}{secondPart}";
                if (PalindromeWord.IsPalindrome(palindromeCandidate))
                {
                    palindromes.Add(palindromeCandidate);
                }
            }

            //firstpart sonda ve secondpart ortada ise => firstpart + secondpart[i] + secondpart
            if ((firstPartIndex + firstPart.Length >= firstWord.Input.Length) && secondPartIndex > 0)
            {
                var palindromeCandidate = $"{firstPart}{secondWord.Input[secondPartIndex - 1]}{secondPart}";
                if (PalindromeWord.IsPalindrome(palindromeCandidate))
                {
                    palindromes.Add(palindromeCandidate);
                }
            }

            //firstpart ortada ve secondpart başta ise => firstpart + firstpart[i] + secondpart
            if ((firstPartIndex + firstPart.Length < firstWord.Input.Length) && secondPartIndex == 0)
            {
                var palindromeCandidate = $"{firstPart}{firstWord.Input[firstPartIndex + firstPart.Length]}{secondPart}";
                if (PalindromeWord.IsPalindrome(palindromeCandidate))
                {
                    palindromes.Add(palindromeCandidate);
                }
            }

            //firstpart ortada ve secondpart ortada ise => firstpart + firstpart[i] + secondpart yada firstpart +secondpart[i] + secondpart
            if ((firstPartIndex + firstPart.Length < firstWord.Input.Length) && secondPartIndex > 0)
            {
                var palindromeCandidate = $"{firstPart}{firstWord.Input[firstPartIndex + firstPart.Length]}{secondPart}";
                if (PalindromeWord.IsPalindrome(palindromeCandidate))
                {
                    palindromes.Add(palindromeCandidate);
                }

                palindromeCandidate = $"{firstPart}{secondWord.Input[secondPartIndex - 1]}{secondPart}";
                if (PalindromeWord.IsPalindrome(palindromeCandidate))
                {
                    palindromes.Add(palindromeCandidate);
                }
            }
        }

        #endregion
    }
}
