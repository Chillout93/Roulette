using System;
using System.Collections.Generic;
using System.Linq;

namespace Roulette
{
    public class Simulator
    {
        private int samples;

        private IList<int> durations;
        private IList<double> maxima;

        private Player player;
        private RouletteGame game;

        public Simulator(RouletteGame game, Player player, int samples)
        { 
            this.samples = samples;
            this.durations = new List<int>();
            this.maxima = new List<double>();
            this.game = game;
            this.player = player;
        }

        private IList<double> Session(Player player)
        {
            Console.WriteLine("New session starting");

            IList<double> stakeValues = new List<double>();
            while (player.IsPlaying)
            {  
                game.Cycle(player);
                stakeValues.Add(player.Stake);
                Console.WriteLine("Player Stake: {0}", player.Stake);
            }

            return stakeValues;
        }

        public ResultSet Gather()
        {
            for (int i = 0; i < samples; i++)
            {
                IList<double> sessionStakes = this.Session(player.DeepClone() as Player);
                this.maxima.Add(sessionStakes.DefaultIfEmpty(0).Last());
                this.durations.Add(sessionStakes.Count);
            }

            return new ResultSet(maxima, durations);
        }
    }

    public class ResultSet
    {
        public IList<double> Maxima { get; private set; }
        public IList<int> Durations { get; private set; }

        public ResultSet(IList<double> maxima, IList<int> durations)
        {
            this.Maxima = maxima;
            this.Durations = durations;
        }
    }
}
