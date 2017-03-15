
using System;
using System.Diagnostics;

namespace MelodiousPassword
{
    public class Program
    {
        //################################################################################
        #region Fields

        private static string m_Consonants = "bcdfghjklmnpqrstvwxz";
        private static string m_Vowels = "aeiou";

        #endregion

        //################################################################################
        #region Public Implementation

        public static void Main(string[] args)
        {
            int passwordLength = Convert.ToInt32(Console.ReadLine());

            //start with vowels
            CreatePassword(passwordLength, string.Empty, true);

            //start with consonants
            CreatePassword(passwordLength, string.Empty, false);
        }

        #endregion

        //################################################################################
        #region Private Implementation

        private static void CreatePassword(int length, string password, bool isVowel)
        {
            string sourceString = string.Empty;
            string tempPassword = password;

            sourceString = isVowel ? m_Vowels : m_Consonants;

            for (int i = 0; i < sourceString.Length; i++)
            {
                password += sourceString[i];
                if (password.Length == length)
                {
                    Console.WriteLine(password);
                    password = tempPassword;
                }
                else
                {
                    CreatePassword(length, password, !isVowel);
                    password = tempPassword;
                }
            }
        }

        #endregion
    }
}
