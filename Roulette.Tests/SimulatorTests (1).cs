using NUnit.Framework;
using System.Collections.Generic;

namespace Roulette.Tests
{
    [TestFixture]
    public class SimulatorTests
    {
        Wheel wheel;
        Table table;
        RouletteGame rg;
        Player player;
        Simulator simulator;

        [SetUp]
        public void Setup()
        {
            wheel = new Wheel(new FakeRandom(1));
            table = new Table(wheel, 1, 50000);
            rg = new RouletteGame(wheel, table);
            player = new MartingalePlayer(1000, table, 250);
            simulator = new Simulator(rg, player, 50);
        }

        [Test]
        public void Simulator_WithZeroRounds_ReturnsZeroList()
        {
            player = new MartingalePlayer(1000, table, 0);
            simulator = new Simulator(rg, player, 50);
            IList<IList<int>> results = simulator.Gather();

            foreach(var result in results[1])
                Assert.AreEqual(result, 0);
        }
    }
}
