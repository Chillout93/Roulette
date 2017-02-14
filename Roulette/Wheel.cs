using System;
using System.Collections.Generic;
using System.Linq;

namespace Roulette
{
    public class Wheel
    {
        public HashSet<Bin> Bins { get; private set; }
        private Random random;

        public Wheel()
        {
            InitialiseBins();
            new BinBuilder(this).BuildBins();
            this.random = new Random();
        }

        public Wheel(Random random)
        {
            InitialiseBins();
            new BinBuilder(this).BuildBins();
            this.random = random;
        }

        public Bin GetBin(int binNumber)
        {
            CheckBinExists(binNumber);

            return Bins.ElementAt(binNumber);
        }

        public int GetBinSize()
        {
            return Bins.Count;
        }

        public void AddOutcomeToBin(int binNumber, Outcome outcome)
        {
            if (outcome == null)
                throw new ArgumentException("Outcome cannot be null");

            this.GetBin(binNumber).AddOutcome(outcome);
        }

        public Bin Spin()
        {
            return this.GetBin(random.Next(Bins.Count));
        }

        private void CheckBinExists(int binNumber)
        {
            if ((Bins.Count - 1) < binNumber)
                throw new ArgumentException("That bin does not exist on the wheel");
        }

        public Outcome GetOutcome(string name)
        {
            foreach (Bin bin in Bins)
                if (bin.GetOutcome(name) != null) 
                    return bin.GetOutcome(name);

            throw new ArgumentException("That outcome does not exist");
        }

        private void InitialiseBins()
        {
            Bins = new HashSet<Bin>()
            {
                {  new Bin("0")  },
                {  new Bin("1")  },
                {  new Bin("2")  },
                {  new Bin("3")  },
                {  new Bin("4")  },
                {  new Bin("5")  },
                {  new Bin("6")  },
                {  new Bin("7")  },
                {  new Bin("8")  },
                {  new Bin("9")  },
                {  new Bin("10") },
                {  new Bin("11") },
                {  new Bin("12") },
                {  new Bin("13") },
                {  new Bin("14") },
                {  new Bin("15") },
                {  new Bin("16") },
                {  new Bin("17") },
                {  new Bin("18") },
                {  new Bin("19") },
                {  new Bin("20") },
                {  new Bin("21") },
                {  new Bin("22") },
                {  new Bin("23") },
                {  new Bin("24") },
                {  new Bin("25") },
                {  new Bin("26") },
                {  new Bin("27") },
                {  new Bin("28") },
                {  new Bin("29") },
                {  new Bin("30") },
                {  new Bin("31") },
                {  new Bin("32") },
                {  new Bin("33") },
                {  new Bin("34") },
                {  new Bin("35") },
                {  new Bin("36") },
                {  new Bin("00") }
            };
        }
    }
}
