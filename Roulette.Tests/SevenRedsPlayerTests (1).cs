using NUnit.Framework;

namespace Roulette.Tests
{
    [TestFixture]
    public class SevenRedsPlayerTests
    {
        SevenRedsPlayer sevenRedsPlayer;
        Simulator simulator;
        RouletteGame rg;
        Table table;
        Wheel wheel;
        Bet bet;

        [SetUp]
        public void SetUp()
        {
            wheel = new Wheel();
            bet = new Bet(sevenRedsPlayer, 1, wheel.GetOutcome("Black"));
            table = new Table(wheel, 1, 500);
            sevenRedsPlayer = new SevenRedsPlayer(500, table, 250);
            rg = new RouletteGame(wheel, table);
            simulator = new Simulator(rg, sevenRedsPlayer, 50);
        }

        [Test]
        public void PlaceBet_WithSevenReds_PlacesBet()
        {
            var redBin = wheel.GetBin(1);
            for(int i = 0; i < 7; i++)
                sevenRedsPlayer.GetWinningBin(redBin);

            int oldStake = sevenRedsPlayer.Stake;
            sevenRedsPlayer.PlaceBet();

            Assert.Greater(oldStake, sevenRedsPlayer.Stake);
        }

        [Test]
        public void PlaceBet_BelowSevenReds_DoesntPlaceBet()
        {
            int oldStake = sevenRedsPlayer.Stake;
            sevenRedsPlayer.PlaceBet();

            Assert.AreEqual(oldStake, sevenRedsPlayer.Stake);
        }

        [Test]
        public void PlaceBet_With6Reds1Black1Red_DoesntPlaceBet()
        {
            var redBin = wheel.GetBin(1);
            for (int i = 0; i < 7; i++)
                sevenRedsPlayer.GetWinningBin(redBin);

            var blackBin = wheel.GetBin(2);
            sevenRedsPlayer.GetWinningBin(blackBin);

            int oldStake = sevenRedsPlayer.Stake;
            sevenRedsPlayer.PlaceBet();

            Assert.AreEqual(oldStake, sevenRedsPlayer.Stake);
        }
    }
}
