using System;
using System.Collections.Generic;
using System.Linq;

namespace Roulette
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Wheel wheel = new Wheel(random);
            Table table = new Table(wheel, 1, 50000);
            RouletteGame rg = new RouletteGame(wheel, table);
            Player player = new CancellationPlayer(100, table, 250);
            Simulator simulator = new Simulator(rg, player, 50);
           
            var lists = simulator.Gather();
            foreach (var session in lists.First().Zip(lists.ElementAt(1), (first, second) => string.Format("Ending Value: {0}, Duration: {1}", first, second)))
                Console.WriteLine(session.ToString());

            Console.Read();
        }
    }
}
