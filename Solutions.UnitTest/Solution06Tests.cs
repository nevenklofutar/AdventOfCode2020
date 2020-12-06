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

        [Test]
        [TestCase("Input06a.txt", 6)]
        [TestCase("Input06b.txt", 3394)]
        public void GetResultTwo_WhenCalled_ReturnsResult(string filePath, int result) {

            var solution = new Solution06();

            var res = solution.GetSolutionTwo(filePath);

            Assert.That(res, Is.EqualTo(result));
        }
    }
}