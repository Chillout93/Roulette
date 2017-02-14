using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    public class CancellationPlayer : Player
    {
        public IList<int> betValues;
        public CancellationPlayer(int startingMoney, Table table, int numberOfRounds) : base(startingMoney, table, numberOfRounds)
        {          
            betValues = new List<int> { 1, 2, 3, 4, 5, 6 };
            bet = new Bet(this, betValues.First() + betValues.Last(), table.GetOutcome("Black"));
        }

        public CancellationPlayer(CancellationPlayer player) : base(player.OriginalStake, player.table, player.NumberOfRounds)
        {
            this.betValues = new List<int> { 1, 2, 3, 4, 5, 6 };
            bet = new Bet(this, betValues.First() + betValues.Last(), table.GetOutcome("Black"));
        }

        public override void Won(Bet bet)
        { 
            base.Won(bet);
            if (betValues.Count <= 2)
            {
                base.ForceStopPlaying();
                this.betValues = new List<int> { 1, 2, 3, 4, 5, 6 };
            }
            else
            {
                betValues.RemoveAt(0);
                betValues.RemoveAt(betValues.Count - 1);
            }
            bet = new Bet(this, betValues.First() + betValues.Last(), table.GetOutcome("Black"));
        }

        public override void Lost(Bet bet)
        {
            base.Lost(bet);
            betValues.Add(bet.Ammount);
            bet = new Bet(this, betValues.First() + betValues.Last(), table.GetOutcome("Black"));
        }

        public override void ResetBet()
        {
            bet = new Bet(this, betValues.First() + betValues.Last(), table.GetOutcome("Black"));
        }

        public override Player DeepClone()
        {
            CancellationPlayer player = new CancellationPlayer(this);
            return player;
        }
    }
}
