using System;

namespace Poker.Library
{
    public class Card: IComparable<Card>
    {
        public Card(CardValue value, CardSuit suit)
        {
            Value = value;
            Suit = suit;
        }

        public CardValue Value { get; }
        public CardSuit Suit { get; }

        public int CompareTo(Card other) => this.Value.CompareTo(other.Value);

        public override string ToString() => $"{Value} of {Suit}";
    }
}
