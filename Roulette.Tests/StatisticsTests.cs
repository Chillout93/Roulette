using NUnit.Framework;
using System.Collections.Generic;

namespace Roulette.Tests
{
    [TestFixture]
    public class StatisticsTests
    {
        private IList<int> values;

        [SetUp]
        public void Setup()
        {
            values = new List<int> { 9, 8, 5, 9, 9, 4, 5, 8, 10, 7, 8, 8 };
        }

        [Test]
        public void Average_WithAnyList_ReturnsCorrectAverage()
        {
            Assert.AreEqual(7.5, Statistics.Mean(values));
        }

        [Test]
        public void StandardDeviation_WithAnyList_ReturnsCorrectly()
        {
            Assert.AreEqual(1.80278, Statistics.StandardDeviation(values));
        }
    }
}
