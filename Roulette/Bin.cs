using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roulette
{
    public class Bin : IEnumerable<Outcome>
    {
        public ICollection<Outcome> Outcomes { get; private set; }
        string binName;

        public Bin(string binName)
        {
            this.Outcomes = new HashSet<Outcome>();
            this.binName = binName;
        }

        public Bin(ICollection<Outcome> Outcomes)
        {
            this.Outcomes = Outcomes;
        }

        public void AddOutcome(Outcome outcome)
        {
            Outcomes.Add(outcome);
        }

        public Outcome GetOutcome(string name)
        {
            return Outcomes.SingleOrDefault(x => x.Name == name);
        }

        public override bool Equals(object obj)
        {
            Bin bin = (Bin)obj;
            if (bin == null)
                return false;

            return this.binName == bin.binName && bin.Outcomes.SequenceEqual(this.Outcomes);
        }

        public override int GetHashCode()
        {
            return this.binName.GetHashCode() + this.Outcomes.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(string.Format("Bin:{0} [", binName));
            sb.Append(string.Join("\n", Outcomes));
            sb.Append("]");

            return sb.ToString();
        }


        public IEnumerator<Outcome> GetEnumerator()
        {
            return Outcomes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
