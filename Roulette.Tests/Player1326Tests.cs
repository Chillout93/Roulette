using NUnit.Framework;
using System;
using System.Linq;

namespace Roulette.Tests
{
    [TestFixture]
    public class Player1326Tests
    {
        Player1326 player;
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
            bet = new Bet(player, 1, wheel.GetOutcome("Black"));
            table = new Table(wheel, 1, 500);
            player = new Player1326(500, table, 250);
            rg = new RouletteGame(wheel, table);
            simulator = new Simulator(rg, player, 50);
        }

        [Test]
        public void PlaceBet_WithNoWins_ReturnsBetValueOfOne()
        {
            Assert.AreEqual(1, player.GetBetAmmount());
        }

        [Test]
        public void PlaceBet_WithOneWin_ReturnsBetValueOfThree()
        {
            player.Won(bet);
            Assert.AreEqual(3, player.GetBetAmmount());
        }

        [Test]
        public void PlaceBet_WithTwoWins_ReturnsBetValueOfTwo()
        {
            player.Won(bet);
            player.Won(bet);

            Assert.AreEqual(2, player.GetBetAmmount());
        }

        [Test]
        public void PlaceBet_WithThreeWins_ReturnsBetValueOfSix()
        {
            for (int i = 0; i < 3; i++)
                player.Won(bet);

            Assert.AreEqual(6, player.GetBetAmmount());
        }

        /* Wheel and RandomPlayer should ALWAYS share a Random instance otherwise because it is based off time, 
           and separate calls to .Next() would create the same number. */
        [Test]
        public void PlaceBet_WithFourWins_ResetsBet()
        {
            for (int i = 0; i < 4; i++)
                player.Won(bet);

            Assert.AreEqual(1, player.GetBetAmmount());
        }
    }
}
