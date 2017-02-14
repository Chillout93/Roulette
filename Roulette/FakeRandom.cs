using System;

namespace Roulette
{
    public class FakeRandom : Random
    {
        private int randomNumberToReturn;

        public FakeRandom(int randomNumberToIgnore)
        {
            // Ignore real random
        }

        public void Seed(int randomNumberToReturn)
        {
            this.randomNumberToReturn = randomNumberToReturn;
        }

        public override int Next()
        {
            return randomNumberToReturn;
        }

        public override int Next(int randomNumberToIgnore)
        {
            return randomNumberToReturn;
        }
    }
}
