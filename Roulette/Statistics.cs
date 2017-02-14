using System;
using System.Collections.Generic;
using System.Linq;

namespace Roulette
{
    public class Statistics
    {
        public static double Mean(IList<int> values)
        {
            return (double)values.Sum() / values.Count;
        }

        public static double StandardDeviation(IEnumerable<int> values)
        {
            return Math.Round(Math.Sqrt(values.Average(v => Math.Pow(v - values.Average(), 2))), 5);
        }
    }
}
