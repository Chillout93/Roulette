using System.Linq;

namespace Roulette
{
    public class BinBuilder
    {
        Wheel wheel;

        public BinBuilder(Wheel wheel)
        {
            this.wheel = wheel;
        }

        public void BuildBins()
        {
            StraightBet();
            SplitBet();
            StreetBet();
            CornerBet();
            LineBet();
            DozenBet();
            EvenMoney();
        }

        private void StraightBet()
        {
            for(int i = 1; i < 37; i++)
                wheel.Bins.ElementAt(i).AddOutcome(new Outcome(i.ToString(), 35));

            wheel.Bins.ElementAt(0).AddOutcome(new Outcome("0", 35));
            wheel.Bins.ElementAt(wheel.Bins.Count - 1).AddOutcome(new Outcome("00", 35));
        }

        private void SplitBet()
        {
            for (int i = 1; i <= 36; i++)
            {
                Outcome outcomeHorizontal = new Outcome(string.Format("Split {0}-{1}", i, i + 1), 17);
                Outcome outcomeVertical = new Outcome(string.Format("Split {0}-{1}", i, i + 3), 17);

                if (i % 3 != 0)
                { 
                    wheel.Bins.ElementAt(i).AddOutcome(outcomeHorizontal);
                    wheel.Bins.ElementAt(i + 1).AddOutcome(outcomeHorizontal);
                }

                if (i <= 33)
                {
                    wheel.Bins.ElementAt(i).AddOutcome(outcomeVertical);
                    wheel.Bins.ElementAt(i + 3).AddOutcome(outcomeVertical);
                }
            }
        }

        private void StreetBet()
        {
            for (int i = 1; i <= 36; i += 3)
            {
                Outcome outcome = new Outcome("Street Bet " + i, 11);
                wheel.Bins.ElementAt(i).AddOutcome(outcome);
                wheel.Bins.ElementAt(i + 1).AddOutcome(outcome);
                wheel.Bins.ElementAt(i + 2).AddOutcome(outcome);
            }
        }

        private void CornerBet()
        {
            for (int i = 0; i < 11; i++)
            {
                int columnNumber = (3 * i) + 1;

                Outcome outcomeFirstColumn = new Outcome(string.Format("Corner Bet {0}-{1}-{2}-{3}", columnNumber, columnNumber + 1, columnNumber + 3, columnNumber + 4), 8);
                wheel.Bins.ElementAt(columnNumber).AddOutcome(outcomeFirstColumn);
                wheel.Bins.ElementAt(columnNumber + 1).AddOutcome(outcomeFirstColumn);
                wheel.Bins.ElementAt(columnNumber + 3).AddOutcome(outcomeFirstColumn);
                wheel.Bins.ElementAt(columnNumber + 4).AddOutcome(outcomeFirstColumn);

                columnNumber = (3 * i) + 2;

                Outcome outcomeSecondColumn = new Outcome(string.Format("Corner Bet {0}-{1}-{2}-{3}", columnNumber, columnNumber + 1, columnNumber + 3, columnNumber + 4), 8);
                wheel.Bins.ElementAt(columnNumber).AddOutcome(outcomeSecondColumn);
                wheel.Bins.ElementAt(columnNumber + 1).AddOutcome(outcomeSecondColumn);
                wheel.Bins.ElementAt(columnNumber + 3).AddOutcome(outcomeSecondColumn);
                wheel.Bins.ElementAt(columnNumber + 4).AddOutcome(outcomeSecondColumn);
            }
        }

        private void LineBet()
        {
            for (int i = 1; i < 12; i += 2)
            {
                int x = (i * 3) + 1;
                Outcome outcome = new Outcome(string.Format("Line Bet {0}-{1}-{2}-{3}-{4}-{5}", x - 3, x - 2, x - 1, x, x + 1, x + 2), 5);
                wheel.Bins.ElementAt(x - 3).AddOutcome(outcome);
                wheel.Bins.ElementAt(x - 2).AddOutcome(outcome);
                wheel.Bins.ElementAt(x - 1).AddOutcome(outcome);
                wheel.Bins.ElementAt(x).AddOutcome(outcome);
                wheel.Bins.ElementAt(x + 1).AddOutcome(outcome);
                wheel.Bins.ElementAt(x + 2).AddOutcome(outcome);
            }
        }

        private void DozenBet()
        {
            for (int i = 0; i <= 2; i++)
            {
                Outcome outcome = new Outcome("Dozen Bet " + (i + 1), 2);
                int x = (i * 12) + 1;
                for (int y = x; y < x + 12; y++)
                    wheel.Bins.ElementAt(y).AddOutcome(outcome);
            }
        }

        private void EvenMoney()
        {
            Outcome even = new Outcome("Even", 1);
            Outcome odd = new Outcome("Odd", 1);
            Outcome red = new Outcome("Red", 1);
            Outcome black = new Outcome("Black", 1);
            Outcome low = new Outcome("Low", 1);
            Outcome high = new Outcome("High", 1);
            int[] redNumbers = new int[] { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };

            for (int i = 1; i <= 36; i++)
            {
                wheel.Bins.ElementAt(i).AddOutcome((i < 19) ? low : high);
                wheel.Bins.ElementAt(i).AddOutcome((i % 2 == 0) ? even : odd);
                wheel.Bins.ElementAt(i).AddOutcome(redNumbers.Contains(i) ? red : black);
            }
        }
    }
}
