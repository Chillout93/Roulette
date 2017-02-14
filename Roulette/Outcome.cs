namespace Roulette
{
    public class Outcome
    {
        public string Name { get; private set; }
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        public Outcome(string name, int numerator, int denominator = 1)
        {
            this.Name = name;
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public double GetWinAmount(int betPlacedValue)
        {
            return (((double)this.Numerator / this.Denominator) * betPlacedValue) + betPlacedValue;
        }

        public override bool Equals(object obj)
        {
            Outcome outcome = (Outcome)obj;
            if (outcome == null)
                return false;

            return this.Name == outcome.Name && this.Numerator == outcome.Numerator;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Numerator.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}: ({1}/{2})", this.Name, this.Numerator, this.Denominator);
        }
    }
}
