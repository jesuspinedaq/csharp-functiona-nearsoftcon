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

        public void Draw(Card card)
        {
            Cards.Add(card);
        }

        public Card HighCard() => Cards.OrderByDescending(x => x.Value).FirstOrDefault();

        public HandRank GetHandRank()
        {
            if (IsRoyalFlush()) return HandRank.RoyalFlush;
            if (IsFourOfAKind()) return HandRank.FourOfAKind;
            if (IsFullHouse()) return HandRank.FullHouse;
            if (IsFlush()) return HandRank.Flush;
            if (IsThreeOfAKind()) return HandRank.ThreeOfAKind;
            if (IsPair()) return HandRank.Pair;
            return HandRank.HighCard;
        }

        private bool IsFullHouse() => IsThreeOfAKind() && IsPair();

        private bool IsFourOfAKind()=>  Cards.ToDicctionaryAndQuantity().Any(x => x.Value == 4);

        private bool IsThreeOfAKind() =>  Cards.ToDicctionaryAndQuantity().Any(x => x.Value == 3);

        private bool IsPair() =>  Cards.ToDicctionaryAndQuantity().Any(x => x.Value == 2);

        private bool IsRoyalFlush() => Cards.All(card => card.Value >= CardValue.Ten) && IsFlush();

        private bool IsFlush() => Cards.All(card => card.Suit == Cards.First().Suit);

    }
}