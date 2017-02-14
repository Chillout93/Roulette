using System.Collections.Generic;
using System.Linq;

namespace Roulette
{
    public class RouletteGame
    {
        Wheel wheel;
        Table table;

        public RouletteGame(Wheel wheel, Table table)
        {
            this.wheel = wheel;
            this.table = table;
        }

        public Bin Cycle(Player player)
        {
            table.ClearBets();
            player.PlaceBet();
            Bin bin = wheel.Spin();

            player.GetWinningBin(bin);

            foreach (Bet bet in table)
            {
                if (bin.Contains(bet.Outcome))
                {
                    player.Won(bet);
                }
                else
                {
                    player.Lost(bet);
                }
            }

            return bin;
        }
    }
}
