namespace HackerRank.Tracks.Algorithms.Strings.BuildPalindrome
{
    public class InnerPalindrome
    {
        //################################################################################
        #region Fields

        private readonly string m_Palindrome;
        private readonly int m_PalindromeLength;
        private readonly int m_StartIndex;

        #endregion

        //################################################################################
        #region Constructor

        public InnerPalindrome(string palindrome, int index)
        {
            m_Palindrome = palindrome;
            m_PalindromeLength = palindrome.Length;
            m_StartIndex = index;
        }

        #endregion

        //################################################################################
        #region Properties

        internal string Palindrome => m_Palindrome;

        internal int Length => m_PalindromeLength;

        internal int StartIndex => m_StartIndex;

        #endregion
    }
}
