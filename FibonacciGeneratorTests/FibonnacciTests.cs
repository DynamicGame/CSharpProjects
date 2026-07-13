using FibonacciGenerator;
using NUnit.Framework;

namespace FibonacciGeneratorTests
{
    [TestFixture]
    public class FibonnacciTests
    {
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        public void Generate_ShallThrowArgumentException_WhenInputIsLessThanZero(int input)
        {
            Assert.Throws<ArgumentException>(() => Fibonacci.Generate(input));
        }


        [TestCase(47)]
        [TestCase(100)]
        [TestCase(1000)]
        public void Generate_ShallThrowArgumentException_WhenInputIsGreaterThan46(int input)
        {
            Assert.Throws<ArgumentException>(() => Fibonacci.Generate(input));
        }


        [TestCase(2)]
        [TestCase(3)]
        public void Generate_LastValueShallBe1_WhenInputIs2or3(int input)
        {
            var result = Fibonacci.Generate(input);
            var expected = 1;
            Assert.AreEqual(expected, result.Last());
        }


        [TestCase(45)]
        [TestCase(11)]
        [TestCase(10)]
        public void Generate_TheLengthShallBeEqualsToInput(int input)
        {
            var result = Fibonacci.Generate(input);
            var expected = input;
            Assert.AreEqual(expected, result.Count());
        }

        [Test]
        public void Generate_ShallReturn_0_1_1_2_3_WhenInputIs5()
        {
            var input = 5;
            var expected = new List<int> { 0, 1, 1, 2, 3 };
            var result = Fibonacci.Generate(input);
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
