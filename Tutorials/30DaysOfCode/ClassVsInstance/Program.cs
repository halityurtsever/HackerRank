using System;

namespace HackerRank.Tutorials._30DaysOfCode.ClassVsInstance
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    class Person
    {
        public int m_Age;

        public Person(int initialAge)
        {
            m_Age = ValidateAge(initialAge);
        }

        internal void yearPasses()
        {
            m_Age++;
        }

        internal void amIOld()
        {
            if (m_Age < 13)
            {
                Console.WriteLine("You are young.");
            }
            else if ((m_Age >= 13) && (m_Age < 18))
            {
                Console.WriteLine("You are a teenager.");
            }
            else
            {
                Console.WriteLine("You are old.");
            }
        }

        private int ValidateAge(int initialAge)
        {
            if (initialAge < 0)
            {
                Console.WriteLine("Age is not valid, setting age to 0.");
                return 0;
            }

            return initialAge;
        }
    }
}
