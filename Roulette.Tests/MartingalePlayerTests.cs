using NUnit.Framework;
using Roulette;

namespace Roulette.Tests
{
    [TestFixture]
    public class MartingalePlayerTests
    {
        MartingalePlayer martingalePlayer;
        Table table;
        Wheel wheel;
        Bet bet;

        [SetUp]
        public void SetUp()
        {
            wheel = new Wheel();
            bet = new Bet(martingalePlayer, 1, wheel.GetOutcome("Black"));
            table = new Table(wheel, 1, 500);
            martingalePlayer = new MartingalePlayer(500, table, 250);
        }

        [Test]
        public void PlaceBet_WithLoss_DoublesBet()
        {
            martingalePlayer.Lost(bet);
            Assert.AreEqual(2, martingalePlayer.GetBetAmmount());
        }

        [Test]
        public void PlaceBet_WithWinThenLoss_EqualsStartingBet()
        {
            martingalePlayer.Won(bet);
            martingalePlayer.Lost(bet);
        }

        [Test]
        public void PlaceBet_WithWin_ResetsBet()
        {
            martingalePlayer.Won(bet);
            Assert.AreEqual(1, martingalePlayer.GetBetAmmount());
        }

        [Test]
        public void ResetBet_AfterSession_GoesBackToDefault()
        {
            martingalePlayer.Lost(bet);
            martingalePlayer.ResetBet();
            Assert.AreEqual(martingalePlayer.GetBetAmmount(), 1);
        }
    }
}
