using System.Collections.Generic;

namespace HackerRank.Tracks.Algorithms.Strings.BuildPalindrome
{
    public class PalindromeWord
    {
        //################################################################################
        #region Fields

        private readonly string m_Input;
        private string m_Palindrome = string.Empty;
        private string m_Reverse = string.Empty;
        private string m_InputWithoutPalindromePart = string.Empty;

        private List<InnerPalindrome> m_InnerPalindromes = new List<InnerPalindrome>();

        #endregion

        //################################################################################
        #region Constructor

        public PalindromeWord(string input)
        {
            m_Input = input;
            m_Reverse = ReverseWord(m_Input);
        }

        #endregion

        //################################################################################
        #region Properties

        internal string Input => m_Input;

        internal string Reverse => m_Reverse;

        internal string PalindromePart
        {
            get { return m_Palindrome; }
            set { m_Palindrome = value; }
        }

        internal List<InnerPalindrome> InnerPalindromes => m_InnerPalindromes;

        #endregion

        //################################################################################
        #region Static Implementation

        internal static string ReverseWord(string input)
        {
            var reverse = string.Empty;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                reverse += input[i];
            }
            return reverse;
        }

        internal static bool IsPalindrome(string input)
        {
            return input == ReverseWord(input) && input.Length > 1;
        }

        #endregion

        //################################################################################
        #region Internal Implementation

        internal void FindInnerPalindrome()
        {
            var index = 0;
            var length = 1;
            var temp = "";

            var lastMatch = string.Empty;
            var lastMatchIndex = 0;
            var lastMatchLength = 0;

            while (true)
            {
                //avoid ArrayOutOfBoundException
                if ((index + length) >= m_InputWithoutPalindromePart.Length)
                    break;

                temp = m_InputWithoutPalindromePart.Substring(index, length);
                if (m_Reverse.Contains(temp))
                {
                    //if found longest match, keep it
                    if (length > lastMatchLength)
                    {
                        lastMatch = temp;
                        lastMatchIndex = m_Input.IndexOf(lastMatch);
                        lastMatchLength = length;

                        if (IsPalindrome(lastMatch))
                        {
                            m_InnerPalindromes.Add(new InnerPalindrome(lastMatch, lastMatchIndex));

                            //optimization: no more check if last found palindrome is longer than remaining of the array
                            if (m_InputWithoutPalindromePart.Length - (lastMatchIndex + lastMatchLength) < lastMatchLength)
                                break;
                        }
                    }

                    length++;
                    continue;
                }

                length = 1;
                temp = "";
                index++;
            }
        }

        internal void ExcludePalindromeAndFindInners()
        {
            if (!string.IsNullOrEmpty(m_Palindrome))
            {
                m_InputWithoutPalindromePart = m_Input.Replace(m_Palindrome, "");
            }
            FindInnerPalindrome();
        }

        #endregion
    }
}
