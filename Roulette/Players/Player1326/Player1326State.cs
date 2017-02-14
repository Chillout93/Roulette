using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    public abstract class Player1326State
    {
        protected Player1326 player;

        public Player1326State(Player1326 player)
        {
            this.player = player;
        }

        public abstract Bet CurrentBet();
        public abstract Player1326State NextWon();
        public abstract Player1326State NextLost();
    }
}
