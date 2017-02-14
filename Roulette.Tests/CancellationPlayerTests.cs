using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Tests
{
    [TestFixture]
    public class CancellationPlayerTests
    {
        CancellationPlayer player;
        Table table;
        Wheel wheel;
        Bet bet;

        [SetUp]
        public void SetUp()
        {
            wheel = new Wheel();
            table = new Table(wheel, 1, 500);
            player = new CancellationPlayer(500, table, 250);
            bet = new Bet(player, player.betValues.First() + player.betValues.Last(), wheel.GetOutcome("Black"));
        }

        [Test]
        public void PlaceBet_WithLoss_AddsToList()
        {
            int originalListCount = player.betValues.Count;
            player.Lost(bet);
            Assert.Greater(player.betValues.Count, originalListCount);
        }

        [Test]
        public void PlaceBet_WithWin_RemovesFromList()
        {
            int originalListCount = player.betValues.Count;
            player.Won(bet);
            /* Should have removed first and last from list. */
            Assert.AreEqual(player.betValues.Count, originalListCount - 2);
        }

        [Test]
        public void PlaceBet_WithWin_CalculatesNewBet()
        {
            int newListBet = player.betValues[1] + player.betValues[player.betValues.Count - 2];
            player.Won(bet);
            /* Should have removed first and last from list. */
            Assert.AreEqual(player.betValues.First() + player.betValues.Last(), newListBet);
        }

        [Test]
        public void PlaceBet_WithLoss_CalculatesNewBet()
        {
            int newListBet = player.betValues.First() + (player.betValues.First() + player.betValues.Last());
            player.Lost(bet);
            /* Should have removed first and last from list. */
            Assert.AreEqual(player.betValues.First() + player.betValues.Last(), newListBet);
        }

        [Test]
        public void PlaceBet_WithEmptyList_LeavesTable()
        {
            /* Winning 3 times from original list should give empty list. */
            player.Won(bet);
            player.Won(bet);
            player.Won(bet);

            Assert.AreEqual(false, player.IsPlaying);
        }
    }
}
