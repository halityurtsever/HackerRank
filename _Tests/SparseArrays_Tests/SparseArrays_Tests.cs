using CodeHelpers;

using NUnit.Framework;

using SparseArrays.Library;

namespace SparseArrays_Tests
{
    [TestFixture]
    public class SparseArrays_Tests : TestBase
    {
        [Test]
        public void TestCase_01()
        {
            TestRunner<ArraySparser>("input_01.txt", "output_01.txt");
        }

        [Test]
        public void TestCase_02()
        {
            TestRunner<ArraySparser>("input_02.txt", "output_02.txt");
        }

        [Test]
        public void TestCase_03()
        {
            TestRunner<ArraySparser>("input_03.txt", "output_03.txt");
        }
    }
}
