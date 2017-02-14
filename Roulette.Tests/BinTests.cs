using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Tests
{
    [TestFixture]
    public class BinTests
    {
        Bin bin;

        [SetUp]
        public void SetUp()
        {
            bin = new Bin("1");
        }

        [Test]
        public void ToString_WithAndWithoutParameters_ReturnsCorrectly()
        {
            Assert.AreEqual("Bin:1 []", bin.ToString());

            bin.AddOutcome(new Outcome("Even", 5));
            bin.AddOutcome(new Outcome("Odd", 5));

            Assert.AreEqual("Bin:1 [Even: (5/1)\nOdd: (5/1)]", bin.ToString());
        }
    }
}
