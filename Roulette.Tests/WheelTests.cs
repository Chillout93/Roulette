using NUnit.Framework;
using System;

namespace Roulette.Tests
{
    [TestFixture]
    class WheelTests
    {
        Wheel wheel;
        BinBuilder binBuilder;

        [SetUp]
        public void SetUp()
        {
            wheel = new Wheel();
            binBuilder = new BinBuilder(wheel);
            binBuilder.BuildBins();
        }

        [Test]
        public void Spin_WithFakeRandom_ReturnsExpectedBin()
        {
            FakeRandom random = new FakeRandom(1);
            random.Seed(3);

            wheel = new Wheel(random);
            Bin bin = wheel.Spin();

            Assert.AreEqual(wheel.GetBin(3), bin);
        }

        [Test]
        public void ToString_WithPopulatedBins_ReturnsCorretly()
        { 
            
        }

        [Test]
        public void Wheel_WithFakeRandom_PopulatesBins()
        {
            Wheel wheel = new Wheel(new FakeRandom(1));

            foreach (var bin in wheel.Bins)
                Assert.AreNotEqual(bin.Outcomes.Count, 0);
        }

        [Test]
        public void GetBin_WithCorrectInt_ReturnsCorrectBin()
        {
            Bin manualBin = new Bin("1");
            manualBin.AddOutcome(new Outcome("1", 35));
            manualBin.AddOutcome(new Outcome("Split 1-2", 17));
            manualBin.AddOutcome(new Outcome("Split 1-4", 17));
            manualBin.AddOutcome(new Outcome("Street Bet 1", 11));
            manualBin.AddOutcome(new Outcome("Corner Bet 1-2-4-5", 8));
            manualBin.AddOutcome(new Outcome("Line Bet 1-2-3-4-5-6", 5));
            manualBin.AddOutcome(new Outcome("Dozen Bet 1", 2));
            manualBin.AddOutcome(new Outcome("Low", 1));
            manualBin.AddOutcome(new Outcome("Odd", 1));
            manualBin.AddOutcome(new Outcome("Red", 1));

            Bin bin = wheel.GetBin(1);
            Assert.AreEqual(manualBin.ToString(), bin.ToString());
        }

        [Test]
        public void GetBin_WithIncorrectInt_ThrowsArgumentException()
        {
            Assert.Throws(typeof(ArgumentException), () => wheel.GetBin(40), "That bin does not exist on the wheel");
        }
    }
}
