using System;
using System.Collections.Generic;

namespace Poker.Library
{
    public class Hand
    {
        public Hand()
        {
            Cards = new List<Card>();
        }
        public List<Card> Cards { get; }

        public void Draw(Card card)
        {
            Cards.Add(card);
        }

        public Card HighCard()
        {
            Cards.Sort();
            return Cards[Cards.Count -1];
        }
    }
}