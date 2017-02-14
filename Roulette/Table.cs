using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roulette
{
    public class Table : IEnumerable
    {
        private Wheel wheel;
        private int maxLimit;
        private int minLimit;
        private ICollection<Bet> bets;

        public Table(Wheel wheel, int minLimit, int maxLimit)
        {
            this.wheel = wheel;
            this.bets = new List<Bet>();
            this.minLimit = minLimit;
            this.maxLimit = maxLimit;
        }

        public void AddBet(Bet bet)
        {
            this.bets.Add(bet);
        }

        public IList<Outcome> GetOutcomes()
        {
            IList<Outcome> outcomes = new List<Outcome>();
            foreach (var bin in wheel.Bins)
                foreach (Outcome outcome in bin)
                    if (!outcomes.Contains(outcome)) outcomes.Add(outcome);

            return outcomes;
        }

        public Outcome GetOutcome(string name)
        {
            return wheel.GetOutcome(name);
        }

        public bool IsValidBet(Bet bet)
        {
            return maxLimit >= bets.Sum(x => x.Ammount) + bet.Ammount && bets.Sum(x => x.Ammount) + bet.Ammount >= minLimit;
        }

        public void PlaceBet(Bet bet)
        {
            bets.Add(bet);
            Console.WriteLine("Placing bet: {0}", bet);
        }

        public void ClearBets()
        {
            bets = new List<Bet>();
        }

        public IEnumerator GetEnumerator()
        {
            return bets.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("Bets on Table: \n");
            foreach (Bet bet in bets)
                sb.AppendLine(bet.ToString());

            return sb.ToString();
        }
    }
}
