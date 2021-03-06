﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    public class Player1326NoWins : Player1326State
    {
        public Player1326NoWins(Player1326 player) : base(player)
        {

        }

        public override Bet CurrentBet()
        {
            return new Bet(player, 1, player.GetOutcome());
        }

        public override Player1326State NextLost()
        {
            return new Player1326NoWins(player);
        }

        public override Player1326State NextWon()
        {
            return new Player1326OneWin(player);
        }
    }
}
