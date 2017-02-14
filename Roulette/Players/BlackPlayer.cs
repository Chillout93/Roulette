using System;

namespace Roulette
{
    public class BlackPlayer : Player
    {
        public BlackPlayer(int startingMoney, Table table, int numberOfRounds) : base(startingMoney, table, numberOfRounds) 
        {
            bet = new Bet(this, 10, base.GetOutcome("Black"));
        }

        public override void ResetBet()
        {
            base.bet = new Bet(this, 10, base.GetOutcome("Black"));
        }
    }
}
