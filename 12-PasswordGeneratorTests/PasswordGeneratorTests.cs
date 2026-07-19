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
        [Test]
        public void Generate_ReturnsLengthEqualToRandomValue_WhenSpecialCharactersDisabled()
        {
            int minLength = 5;
            int maxLength = 10;
            int randomNumber = 6;
            
            bool shallUseSpecialCharacters = false;

            _random.Setup(mock => mock.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(randomNumber);
                
            
            var result = _cut.Generate(minLength, maxLength, shallUseSpecialCharacters);

            Assert.AreEqual(randomNumber, result.Length);
        }

    }
}
