using System;

namespace Roulette
{
    public class MartingalePlayer : Player
    {
        private int lossCount;
        private int betAmmount;

        public MartingalePlayer(int startingMoney, Table table, int numberOfRounds) : base(startingMoney, table, numberOfRounds) 
        {
            lossCount = 0;
            betAmmount = 1;
            bet = new Bet(this, betAmmount, base.GetOutcome("Black"));
        }

        public override void Won(Bet bet)
        {
            lossCount = 0;
            base.Won(bet);
            base.bet.Ammount = betAmmount * (int)Math.Pow(2, lossCount);
        }

        public override void Lost(Bet bet)
        {
            lossCount++;
            base.Lost(bet);
            base.bet.Ammount = betAmmount * (int)Math.Pow(2, lossCount);
        }

        public override void ResetBet()
        {
            lossCount = 0;
            base.bet = new Bet(this, betAmmount, base.GetOutcome("Black"));
        }
    }
}
