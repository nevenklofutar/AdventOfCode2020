using NUnit.Framework;
using Solutions.Classes;

namespace Solutions.UnitTest {

    public class Solution06Tests {

        [SetUp]
        public void Setup() {
        }

        [Test]
        [TestCase("Input06a.txt", 11)]
        [TestCase("Input06b.txt", 6809)]
        public void GetResultOne_WhenCalled_ReturnsResult(string filePath, int result) {

            var solution = new Solution06();

            var res = solution.GetSolutionOne(filePath);

            Assert.That(res, Is.EqualTo(result));
        }
    }
}