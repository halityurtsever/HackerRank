using CodeHelpers;

using NUnit.Framework;

using QueueTwoStacks.Library;

namespace QueueTwoStacks_Tests
{
    [TestFixture]
    public class QueueTwoStacks_Tests : TestBase
    {
        //################################################################################
        #region Tests

        [TestCase]
        public void TestCase_01()
        {
            TestRunner<TwoStacksQueuer>("input_01.txt", "output_01.txt");
        }

        #endregion
    }
}
