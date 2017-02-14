using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    public class RandomPlayer : Player
    {
        private readonly IList<Outcome> outcomes;
        private readonly Random random;

        public RandomPlayer(int startingMoney, Table table, int numberOfRounds, Random random) : base(startingMoney, table, numberOfRounds)
        {
            outcomes = table.GetOutcomes();
            this.random = random;
            base.bet = new Bet(this, 10, outcomes[random.Next(outcomes.Count)]);
        }

        public override void Lost(Bet bet)
        {
            base.Lost(bet);
            base.bet = new Bet(this, 10, outcomes[random.Next(outcomes.Count)]);
        }

        public override void Won(Bet bet)
        {
            base.Won(bet);
            base.bet = new Bet(this, 10, outcomes[random.Next(outcomes.Count)]);
        }

        public override void ResetBet()
        {
            base.bet = new Bet(this, 10, outcomes[random.Next(outcomes.Count)]);
        }
    }
}
