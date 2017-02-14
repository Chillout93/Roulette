using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    /// <summary>
    /// On the Internet, we found descriptions of a betting system called the “1-3-2-6” system. This system looks to recoup losses by waiting for four wins in a row. 
    /// The sequence of numbers (1, 3, 2 and 6) are the multipliers to use when placing bets after winning. At each loss, the sequence resets to the multiplier of 1. 
    /// At each win, the multiplier is advanced. After one win, the bet is now 3x. After a second win, the bet is reduced to 2x, and the winnings of 4x are 
    /// “taken down” or removed from play. In the event of a third win, the bet is advanced to 6x. Should there be a fourth win, the player has doubled their money, 
    /// and the sequence resets.
    /// </summary>
    public class Player1326 : Player
    {
        private Player1326State betState;

        public Player1326(int startingMoney, Table table, int numberOfRounds) : base(startingMoney, table, numberOfRounds)
        {
            betState = new Player1326NoWins(this);
            base.bet = betState.CurrentBet();
        }

        public override void ResetBet()
        {
            base.bet = betState.CurrentBet();
        }

        public Outcome GetOutcome()
        {
            return base.GetOutcome("Black");
        }

        public override Bet PlaceBet()
        {
            return base.PlaceBet();
        }

        public override void Lost(Bet bet)
        {
            base.Lost(bet);
            betState = betState.NextLost();
            base.bet = betState.CurrentBet();
        }

        public override void Won(Bet bet)
        {
            base.Won(bet);
            betState = betState.NextWon();
            base.bet = betState.CurrentBet();
        }
    }
}
