using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Tests
{
    [TestFixture]
    class BinBuilderTests
    {
        BinBuilder binBuilder;
        Wheel wheel;

        [SetUp]
        public void SetUp()
        {
            wheel = new Wheel();
            binBuilder = new BinBuilder(wheel);
            binBuilder.BuildBins();
        }

        [Test]
        public void BuildBins_WithWheel_SetsSplitBetCorrectly()
        {
            // Left Column Bottom
            Assert.IsNotNull(wheel.GetBin(34).GetOutcome("Split 31-34"));
            Assert.IsNotNull(wheel.GetBin(34).GetOutcome("Split 34-35"));
            
            // Right Column Middle
            Assert.IsNotNull(wheel.GetBin(6).GetOutcome("Split 3-6"));
            Assert.IsNotNull(wheel.GetBin(6).GetOutcome("Split 5-6"));
            Assert.IsNotNull(wheel.GetBin(6).GetOutcome("Split 6-9"));

            // Middle Column Top
            Assert.IsNotNull(wheel.GetBin(2).GetOutcome("Split 1-2"));
            Assert.IsNotNull(wheel.GetBin(2).GetOutcome("Split 2-3"));
        }

        [Test]
        public void BuildBins_WithWheel_SetsStraightBetCorrectly()
        {
            Assert.IsNotNull(wheel.GetBin(37).GetOutcome("00"));
            Assert.IsNotNull(wheel.GetBin(0).GetOutcome("0"));
            Assert.IsNotNull(wheel.GetBin(1).GetOutcome("1"));
        }

        [Test]
        public void BuildBins_WithWheel_SetsStreetBetCorrectly()
        {
            Assert.IsNull(wheel.GetBin(0).GetOutcome("Street Bet 0"));
            Assert.IsNotNull(wheel.GetBin(2).GetOutcome("Street Bet 1"));
            Assert.IsNotNull(wheel.GetBin(36).GetOutcome("Street Bet 34"));
        }

        [Test]
        public void BuildBins_WithWheel_SetsCornerBetCorrectly()
        {
            Assert.IsNotNull(wheel.GetBin(1).GetOutcome("Corner Bet 1-2-4-5"));
            Assert.IsNotNull(wheel.GetBin(36).GetOutcome("Corner Bet 32-33-35-36"));
            Assert.IsNotNull(wheel.GetBin(17).GetOutcome("Corner Bet 17-18-20-21"));
            Assert.IsNotNull(wheel.GetBin(17).GetOutcome("Corner Bet 13-14-16-17"));
            Assert.IsNotNull(wheel.GetBin(17).GetOutcome("Corner Bet 14-15-17-18"));
            Assert.IsNotNull(wheel.GetBin(17).GetOutcome("Corner Bet 16-17-19-20"));

            Assert.IsNull(wheel.GetBin(17).GetOutcome("Corner Bet 20-21-23-24"));
        }

        [Test]
        public void BuildBins_WithWheel_SetsLineBetCorrectly()
        {
            Assert.IsNotNull(wheel.GetBin(1).GetOutcome("Line Bet 1-2-3-4-5-6"));
            Assert.IsNotNull(wheel.GetBin(21).GetOutcome("Line Bet 19-20-21-22-23-24"));
        }

        [Test]
        public void BuildBins_WithWheel_SetsDozenBetCorrectly()
        {
            Assert.IsNotNull(wheel.GetBin(12).GetOutcome("Dozen Bet 1"));
            Assert.IsNotNull(wheel.GetBin(24).GetOutcome("Dozen Bet 2"));
            Assert.IsNotNull(wheel.GetBin(36).GetOutcome("Dozen Bet 3"));
        }

        [Test]
        public void BuildBins_WithWheel_SetsEvenMoneyBetCorrectly()
        {
            Assert.IsNotNull(wheel.GetBin(1).GetOutcome("Low"));
            Assert.IsNotNull(wheel.GetBin(1).GetOutcome("Odd"));
            Assert.IsNotNull(wheel.GetBin(1).GetOutcome("Red"));
        }
    }
}
