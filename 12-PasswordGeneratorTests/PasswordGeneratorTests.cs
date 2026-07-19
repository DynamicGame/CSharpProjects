using _12_PasswordGenerator.App;
using _12_PasswordGenerator.RandomNumberGenerator;
using Moq;
using NUnit.Framework;
using System.Security.Cryptography.X509Certificates;

namespace _12_PasswordGeneratorTests
{
    [TestFixture]
    public class PasswordGeneratorTests
    {
        private Mock<IRandom> _random;
        private PasswordGenerator _cut;
        [SetUp]
        public void SetUp()
        {
            _random = new Mock<IRandom>();
            _cut = new PasswordGenerator(_random.Object);
        }
        [TestCase(5, 10, 6, false)]
        [TestCase(3, 8, 7, true)]
        [TestCase(8, 15, 12, false)]
        [TestCase(7, 10, 9, true)]
        public void Generate_ReturnsLengthEqualToRandomValue(int minLength, int maxLength, int expectedResult, bool shallUseSpecialCharacters)
        {
            ArrangeRandomNextWithIsAnyValue(expectedResult);

            var result = _cut.Generate(minLength, maxLength, shallUseSpecialCharacters);

            Assert.AreEqual(expectedResult, result.Length);
        }



        [TestCase(5, 10, new[] { 2, 3, 4, 5 }, true, "CDEF")]
        [TestCase(5, 10, new[] { 2, 3, 4, 5,6,7}, true, "CDEFGH")]
        [TestCase(5, 10, new[] { 2, 3, 4, 5,6,7,8,9}, true, "CDEFGHIJ")]
        [TestCase(5, 10, new[] { 2, 3, 4}, true, "CDE")]
        public void Generate_ReturnsStringFromRandomNextSequence(int minLength, int maxLength, int[] generatedCharactersIndex, bool shallUseSpecialCharacter, string expectedResult)
        {
            ArrangeRandomNextWithIsAnyValue(generatedCharactersIndex.Length);
            ArrangeRandomNextReturnsSequence(generatedCharactersIndex);
            var result = _cut.Generate(minLength, maxLength, shallUseSpecialCharacter);

            Assert.AreEqual(expectedResult, result);

        }

        [TestCase(10,5,true)]
        [TestCase(-7,5,true)]
        public void Generate_ThrowsArgumentOutOfRangeException_WhenMinGreaterThanMaxOrNegativeMin(int minLength, int maxLength, bool shallUseSpecialCharacter)
        {
            ArrangeRandomNextWithIsAnyValue(6);

            Assert.Throws<ArgumentOutOfRangeException>(() => _cut.Generate(minLength, maxLength, shallUseSpecialCharacter));
        }

        

        private void ArrangeRandomNextWithIsAnyValue(int expectedResult)
        {
            _random.Setup(mock => mock.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(expectedResult);
        }
        private void ArrangeRandomNextReturnsSequence(int[] generatedCharactersIndex)
        {
            var sequence = _random.SetupSequence(mock => mock.Next(It.IsAny<int>()));

            foreach (var generatedCharacter in generatedCharactersIndex)
            {
                sequence = sequence.Returns(generatedCharacter);
            }
        }
    }
}
