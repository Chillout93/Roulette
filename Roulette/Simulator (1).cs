using System;
using System.Collections.Generic;
using System.Linq;

namespace Roulette
{
    public class Simulator
    {
        private int samples;

        private IList<int> durations;
        private IList<int> maxima;

        private Player player;
        private RouletteGame game;

        public Simulator(RouletteGame game, Player player, int samples)
        { 
            this.samples = samples;
            this.durations = new List<int>();
            this.maxima = new List<int>();
            this.game = game;
            this.player = player;
        }

        private IList<int> Session(Player player)
        {
            Console.WriteLine("New session starting");

            IList<int> stakeValues = new List<int>();
            while (player.IsPlaying)
            {  
                game.Cycle(player);
                stakeValues.Add(player.Stake);
                Console.WriteLine("Player Stake: {0}", player.Stake);
            }

            return stakeValues;
        }

        public IList<IList<int>> Gather()
        {
            for (int i = 0; i < samples; i++)
            {
                IList<int> sessionStakes = this.Session(player.DeepClone() as Player);
                this.maxima.Add(sessionStakes.DefaultIfEmpty(0).Last());
                this.durations.Add(sessionStakes.Count);
            }

            return new List<IList<int>>() { this.maxima, this.durations };
        }
    }
}
