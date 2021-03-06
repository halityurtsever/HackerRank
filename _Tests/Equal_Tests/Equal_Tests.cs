﻿using CodeHelpers;

using Equal.Library;

using NUnit.Framework;

namespace Equal_Tests
{
    [TestFixture]
    public class Equal_Tests : TestBase
    {
        //################################################################################
        #region Tests

        [Test]
        public void TestCase_01()
        {
            TestRunner<EqualSolver>("input_01.txt", "output_01.txt");
        }

        [Test]
        public void TestCase_02()
        {
            TestRunner<EqualSolver>("input_02.txt", "output_02.txt");
        }

        [Test]
        public void TestCase_03()
        {
            TestRunner<EqualSolver>("input_03.txt", "output_03.txt");
        }

        [Test]
        public void TestCase_04()
        {
            TestRunner<EqualSolver>("input_04.txt", "output_04.txt");
        }

        [Test]
        public void TestCase_05()
        {
            TestRunner<EqualSolver>("input_05.txt", "output_05.txt");
        }

        [Test]
        public void TestCase_06()
        {
            TestRunner<EqualSolver>("input_06.txt", "output_06.txt");
        }

        [Test]
        public void TestCase_07()
        {
            TestRunner<EqualSolver>("input_07.txt", "output_07.txt");
        }

        [Test]
        public void TestCase_08()
        {
            TestRunner<EqualSolver>("input_08.txt", "output_08.txt");
        }

        [Test]
        public void TestCase_09()
        {
            TestRunner<EqualSolver>("input_09.txt", "output_09.txt");
        }

        [Test, Explicit]
        public void TestCase_10()
        {
            TestRunner<EqualSolver>("input_10.txt", "output_10.txt");
        }

        #endregion
    }
}