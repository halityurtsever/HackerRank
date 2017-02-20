using System;

namespace HackerRank.Tutorials._30DaysOfCode.Inheritance
{
    class Program
    {
        static void Main()
        {
            string[] inputs = Console.ReadLine().Split();
            string firstName = inputs[0];
            string lastName = inputs[1];
            int id = Convert.ToInt32(inputs[2]);
            int numScores = Convert.ToInt32(Console.ReadLine());
            inputs = Console.ReadLine().Split();
            int[] scores = new int[numScores];
            for (int i = 0; i < numScores; i++)
            {
                scores[i] = Convert.ToInt32(inputs[i]);
            }

            Student s = new Student(firstName, lastName, id, scores);
            s.printPerson();
            Console.WriteLine("Grade: " + s.calculate() + "\n");
        }
    }

    class Person
    {
        protected string firstName;
        protected string lastName;
        protected int id;

        public Person() { }
        public Person(string firstName, string lastName, int identification)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.id = identification;
        }
        public void printPerson()
        {
            Console.WriteLine("Name: " + lastName + ", " + firstName + "\nID: " + id);
        }
    }

    class Student : Person
    {
        private int[] scores;

        public Student(string firstName, string lastName, int identification, int[] scores) : base(firstName, lastName, identification)
        {
            this.scores = scores;
        }

        internal string calculate()
        {
            var totalScore = 0;
            for (int i = 0; i < scores.Length; i++)
            {
                totalScore += scores[i];
            }

            var average = totalScore / scores.Length;

            if (average >= 90 && average <= 100)
                return "O";

            if (average >= 80 && average < 90)
                return "E";

            if (average >= 70 && average < 80)
                return "A";

            if (average >= 55 && average < 70)
                return "P";

            if (average >= 40 && average < 55)
                return "D";

            if (average < 40)
                return "T";

            return string.Empty;
        }
    }
}
