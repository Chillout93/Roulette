using System;

namespace Roulette
{
    public abstract class Player
    {
        public int OriginalStake { get; }
        public double Stake { get; set; }
        protected Bet bet;
        protected Table table;
        public int NumberOfRounds { get; set; }
        public bool isForcedStopPlaying;
        public bool IsPlaying { get { return NumberOfRounds > 0 && Stake - bet.Ammount > 0 && !isForcedStopPlaying; } }

        public Player(int startingMoney, Table table, int numberOfRounds)
        {
            this.isForcedStopPlaying = false;
            this.NumberOfRounds = numberOfRounds;
            this.table = table;
            this.Stake = startingMoney;
            this.OriginalStake = startingMoney;
        }

        public virtual Bet PlaceBet()
        {
            if (Stake - bet.Ammount < 0)
                throw new InvalidPlaceBetException();

            if (!table.IsValidBet(bet))
                throw new InvalidBetException();
            
            table.PlaceBet(bet);
            Stake -= bet.Ammount;
            NumberOfRounds--;

            /* Returns bet for testing and logging rather than business logic */
            return bet;
        }

        public Bet GetBet()
        {
            return bet;
        }

        public Outcome GetOutcome(string name)
        {
            return this.table.GetOutcome(name);
        }

        public virtual void Won(Bet bet)
        {
            Stake += bet.WinAmount();
            Console.WriteLine("Player has won {0}!", bet.WinAmount());
        }

        public virtual void Lost(Bet bet)
        {
            // Ammount gets deducted during place bet so no action needed.
            Console.WriteLine("Player has lost {0}!", bet.LoseAmount());
        }

        public int GetBetAmmount()
        {
            return bet.Ammount;
        }

        public void ForceStopPlaying()
        {
            isForcedStopPlaying = true;
        }

        public virtual Player DeepClone()
        {
            return this.MemberwiseClone() as Player;
        }

        public abstract void ResetBet();

        public virtual void GetWinningBin(Bin bin) { }
    }
}
