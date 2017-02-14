using NUnit.Framework;
using System;


namespace Roulette.UnitTesting
{
    [TestFixture]
    public class OutcomeTests
    {
        Outcome outcome;

        [SetUp]
        public void Setup()
        {
            outcome = new Outcome("Test", 5);        
        }

        [Test]
        public void GetWinAmount_WithNumber_ReturnsCorrectly()
        {   
            Assert.AreEqual(12, outcome.GetWinAmount(2));
        }

        [Test]
        public void Equals_WithMatch_ReturnsTrue()
        {
            Outcome match = new Outcome("Test", 5);

            Assert.IsTrue(match.Equals(outcome));
            Assert.IsTrue(outcome.Equals(match));
        }

        [Test]
        public void Equals_WithIncorrectMatchOrNull_ReturnsFalse()
        {
            Outcome match = new Outcome("IncorrectMatch", 5);

            Assert.IsFalse(match.Equals(outcome));
            Assert.IsFalse(outcome.Equals(match));
            Assert.IsFalse(outcome.Equals(null));
        }

        [Test]
        public void ToString_DefaultValues_ReturnsCorrectly()
        {
            Assert.AreEqual("Test: (5/1)", outcome.ToString());
        }

        [Test]
        public void GetWinAmount_WithOptionalDenominatorOutcome_ReturnsCorrectly()
        {
            int numerator = 4;
            int denominator = 7;
            int bet = 7;

            Outcome outcome = new Outcome("OptionalDenominator", numerator, denominator);
            Assert.AreEqual(11, outcome.GetWinAmount(bet));

        }
    }
}
