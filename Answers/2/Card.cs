using System;

namespace Poker.Library
{
    public class Card
    {
        public Card(CardValue value, CardSuit suit)
        {
            Value = value;
            Suit = suit;
        }

        public CardValue Value { get; set; }
        public CardSuit Suit { get; set; }

        public override string ToString()
        {
            return string.Format("{0} of {1}", Value, Suit);
        }
    }
}
