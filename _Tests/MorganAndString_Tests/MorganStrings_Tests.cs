﻿using CodeHelpers;

using MorganAndString.Library;

using NUnit.Framework;

namespace MorganAndString_Tests
{
    [TestFixture, Explicit]
    public class MorganStrings_Tests : TestBase
    {
        //################################################################################
        #region Tests

        [Test]
        public void TestCase_01()
        {
            TestRunner<MorganStrings>("input_01.txt", "output_01.txt");
        }

        [Test]
        public void TestCase_02()
        {
            TestRunner<MorganStrings>("input_02.txt", "output_02.txt");
        }

        [Test]
        public void TestCase_03()
        {
            TestRunner<MorganStrings>("input_03.txt", "output_03.txt");
        }

        #endregion
    }
}
