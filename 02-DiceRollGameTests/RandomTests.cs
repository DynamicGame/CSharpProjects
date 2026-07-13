using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Random = DiceRollGame.Game.Random;
namespace _02_DiceRollGameTests
{
    internal class RandomTests
    {
        [TestCase(1,5)]
        [TestCase(2,7)]
        [TestCase(8,10)]
        public void Next_ReturnsValueBetweenMinAndMax(int min, int max)
        {
            var _cut = new Random();

            var result = _cut.Next(min, max);

            Assert.That(result, Is.InRange(min, max));
        }
    }
}
