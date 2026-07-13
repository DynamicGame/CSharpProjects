using DiceRollGame.Game;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02_DiceRollGameTests
{
    internal class DiceGameTests
    {
        private  DiceGame _cut;
        private  Mock<IUserInteractor> _userInteractor;
        private  Mock<IDice> _dice;

        [SetUp]
        public void Setup() 
        {
            _userInteractor = new Mock<IUserInteractor>();
            _dice = new Mock<IDice>();
            _cut = new DiceGame(_dice.Object, _userInteractor.Object);
        }

        [Test]
        public void Play_ShallReturnGameResultWinWhenUserGuessIsCorrect()
        {
            var expectedResult = GameResult.Win;
            _dice.Setup(mock => mock.Roll()).Returns(4);

            _userInteractor.Setup(mock => mock.ReadIntegar(It.IsAny<string>())).Returns(4);

            var result = _cut.Play();

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Play_ReturnGameResultLost_WhenUserGuessIsNotEqualDiceRoll()
        {
            var expectedResult = GameResult.Lost;
            GameResult result = FailMethodCall();

            Assert.AreEqual(expectedResult, result);

        }

        private GameResult FailMethodCall()
        {
            _dice.Setup(mock => mock.Roll()).Returns(4);

            _userInteractor.Setup(mock => mock.ReadIntegar(It.IsAny<string>())).Returns(3);

            var result = _cut.Play();
            return result;
        }

        [Test]
        public void Play_CallUserInteractorShowMessageWithSpecificParameter()
        {
            _cut.Play();
            _userInteractor.Verify(mock => mock.ShowMessage("Dice rolled. Guess what number it shows in 3 tries."));
        }
        [Test]
        public void Play_CallsUserInteractorShowMessageWithWrongNumberAsOutputForSpecificTime()
        {
            var tries = DiceGame.MaxTries;
            FailMethodCall();
            _userInteractor.Verify(mock => mock.ShowMessage("Wrong number"), Times.Exactly(tries));
        }

        [Test]
        public void Play_ShallReturnGameResultWinAfterThirdTry()
        {
            var expectedResult = GameResult.Win;
            _dice.Setup(mock => mock.Roll()).Returns(4);

            _userInteractor.SetupSequence(mock => mock.ReadIntegar(It.IsAny<string>()))
                .Returns(2)
                .Returns(3)
                .Returns(4);

            var result = _cut.Play();
            Assert.AreEqual(expectedResult, result);

        }

        [Test]
        public void Play_CallsUserInteractorReadIntegarExactlyMaxTriesWhenUserFailsToGuess()
        {
            var tries = DiceGame.MaxTries;
            FailMethodCall();

            _userInteractor.Verify(mock => mock.ReadIntegar(It.IsAny<string>()), Times.Exactly(tries));
        }

        [TestCase(GameResult.Lost)]
        [TestCase(GameResult.Win)]
        public void PrintResult_ShowsCorrectMessageForWinAndLoss(GameResult gameResult)
        {
           
             _cut.PrintResult(gameResult);
            _userInteractor.Verify(mock => mock.ShowMessage(gameResult == GameResult.Win ? "You win!" : "You lost!"));
        }
    }
}
