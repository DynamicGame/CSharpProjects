using DiceRollGame.Game;
using Moq;
using NUnit.Framework;

namespace _02_DiceRollGameTests
{
    [TestFixture]
    public class DiceTests
    {
        private Mock<IRandom> _random;
        private Dice _cut;

        [SetUp]
        public void Setup()
        {
            _random = new Mock<IRandom>();
            _cut = new Dice(_random.Object);
        }

        [TestCase(1, 6)]
        [TestCase(1, 6)]
        [TestCase(1, 6)]
        public void Roll_ReturnsNumberBetweenMinandMaxPlusOne(int min, int max)
        {
            _random
                .SetupSequence(mock => mock.Next(min, max + 1))
                .Returns(5)
                .Returns(2)
                .Returns(4);

            int result = _cut.Roll();

            Assert.That (result, Is.InRange(min, max + 1));

        }

        [Test]
        public void Roll_CallsRandomNextMethodWithRightValue()
        {
            int minSide = 1;
            int maxSide = Dice.Sides;
            _cut.Roll();

            _random.Verify(mock => mock.Next(minSide, maxSide + 1));
        }

        [TestCase(1,6,2)]
        [TestCase(1,6,3)]
        [TestCase(1,6,4)]
        public void Roll_ReturnsExpectedResult_WhenUsing1AsMinValueAnd6AsMax(int min, int max, int expectedResult)
        {
            _random.Setup(mock => mock.Next(min, max + 1)).Returns(expectedResult);
            var result = _cut.Roll();

            Assert.AreEqual(expectedResult, result);

        }
    }
}
