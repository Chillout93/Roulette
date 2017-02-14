using NUnit.Framework;
using System;

namespace Roulette.Tests
{
    [TestFixture]
    public class RandomPlayerTests
    {
        RandomPlayer randomPlayer;
        Simulator simulator;
        RouletteGame rg;
        Table table;
        Wheel wheel;
        Bet bet;
        Random random;

        [SetUp]
        public void SetUp()
        {
            random = new FakeRandom(1);
            wheel = new Wheel(random);
            bet = new Bet(randomPlayer, 1, wheel.GetOutcome("Black"));
            table = new Table(wheel, 1, 500);
            randomPlayer = new RandomPlayer(500, table, 250, random);
            rg = new RouletteGame(wheel, table);
            simulator = new Simulator(rg, randomPlayer, 50);
        }

        [Test]
        public void PlaceBet_WithFakeRandom_PlacesExpectedBet()
        {
            int randomNumber = random.Next();
            Outcome outcome = table.GetOutcomes()[randomNumber];

            Assert.AreEqual(outcome, randomPlayer.GetBet().Outcome);
        }

        /* Wheel and RandomPlayer should ALWAYS share a Random instance otherwise because it is based off time, 
           and separate calls to .Next() would create the same number. */
        [Test]
        public void PlaceBet_WithFakeRandom_AlwaysWins()
        {
            double oldStake = randomPlayer.Stake;
            rg.Cycle(randomPlayer);

            Assert.Greater(randomPlayer.Stake, oldStake);
        }
    }
}
