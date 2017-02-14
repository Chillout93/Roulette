using System;

namespace Roulette
{
    class InvalidBetException : Exception
    {
        public InvalidBetException() : base("That bet is below the min limit or above the max limit of the table") { }
    }

    class InvalidPlaceBetException : Exception
    {
        public InvalidPlaceBetException() : base("That bet would reduce the players stake below 0") { }
    }
}
