using System;

namespace Roulette
{
    public class SevenRedsPlayer : Player
    {
        private int lossCount;
        private int betAmmount;
        private int seenReds;

        public SevenRedsPlayer(int startingMoney, Table table, int numberOfRounds) : base(startingMoney, table, numberOfRounds) 
        {
            lossCount = 0;
            betAmmount = 1;
            seenReds = 0;
            bet = new Bet(this, 10, base.GetOutcome("Black"));
        }

        public override Bet PlaceBet()
        {
            if (Stake - bet.Ammount < 0)
                throw new InvalidPlaceBetException();

            if (!base.table.IsValidBet(bet))
                throw new InvalidBetException();

            if (seenReds >= 6)
            {
                base.table.PlaceBet(bet);
                Stake -= bet.Ammount;
            }

            return bet;
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

        public override void GetWinningBin(Bin bin)
        {
            if (bin.GetOutcome("Red") != null)
                seenReds++;
            else
                seenReds = 0;
        }
    }
}
