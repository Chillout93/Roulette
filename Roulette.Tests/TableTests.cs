using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Tests
{
    [TestFixture]
    class TableTests
    {
        Table table;
        Wheel wheel;
        int minLimit;
        int maxLimit;

        [SetUp]
        public void SetUp()
        {
            wheel = new Wheel();
            minLimit = 2;
            maxLimit = 200;
            table = new Table(wheel, minLimit, maxLimit);
        }
    }
}
