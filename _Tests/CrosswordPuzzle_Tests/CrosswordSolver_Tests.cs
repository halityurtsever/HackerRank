﻿using CodeHelpers;

using CrosswordPuzzle.Library;

using NUnit.Framework;

namespace CrosswordPuzzle_Tests
{
    [TestFixture]
    public class CrosswordSolver_Tests : TestBase
    {
        //################################################################################
        #region Tests

        [Test]
        public void TestCase_01()
        {
            TestRunner<CrosswordSolver>("input_01.txt", "output_01.txt");
        }

        [Test]
        public void TestCase_02()
        {
            TestRunner<CrosswordSolver>("input_02.txt", "output_02.txt");
        }

        [Test]
        public void TestCase_03()
        {
            TestRunner<CrosswordSolver>("input_03.txt", "output_03.txt");
        }

        [Test]
        public void TestCase_04()
        {
            TestRunner<CrosswordSolver>("input_04.txt", "output_04.txt");
        }

        [Test]
        public void TestCase_05()
        {
            TestRunner<CrosswordSolver>("input_05.txt", "output_05.txt");
        }

        [Test]
        public void TestCase_06()
        {
            TestRunner<CrosswordSolver>("input_06.txt", "output_06.txt");
        }

        #endregion
    }
}
