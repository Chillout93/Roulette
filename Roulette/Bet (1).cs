namespace Roulette
{
    public class Bet
    {
        public Player Player { get; private set; }
        public int Ammount { get; set;  }
        public Outcome Outcome { get; private set;  }

        public Bet(Player player, int ammount, Outcome outcome)
        {
            this.Player = player;
            this.Ammount = ammount;
            this.Outcome = outcome;
        }

        public int WinAmount()
        {
            return (Ammount * Outcome.Numerator) + Ammount;        
        }

        public int LoseAmount()
        {
            return Ammount;
        }

        public override string ToString()
        {
            return string.Format("Ammount: {0}, Outcome: {1}", this.Ammount, this.Outcome);
        }
    }
}
