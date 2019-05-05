using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Library
{
    public class Hand
    {
        public Hand()
        {
            Cards = new List<Card>();
        }
        public List<Card> Cards { get; }

        public void Draw(Card card) => Cards.Add(card);


        public Card HighCard() => Cards.OrderByDescending(x => x.Value).FirstOrDefault();

        public HandRank GetHandRank()
        {
            if (IsRoyalFlush()) return HandRank.RoyalFlush;
            if (IsFlush()) return HandRank.Flush;
            return HandRank.HighCard;
        }
        private bool IsRoyalFlush() => IsFlush() && Cards.All(card => card.Value >= CardValue.Ten);

        private bool IsFlush() => Cards.All(card => card.Suit == Cards.First().Suit);
    }
}