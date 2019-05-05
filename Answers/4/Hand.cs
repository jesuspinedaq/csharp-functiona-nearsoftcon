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

        public Card HighCard()
        {
            Cards.Sort();
            return Cards[Cards.Count - 1];
        }

        public HandRank GetHandRank()
        {
            if (IsRoyalFlush())
                return HandRank.RoyalFlush;
            if (IsFlush())
                return HandRank.Flush;

            return HandRank.HighCard;
        }
        private bool IsRoyalFlush()
        {
            Cards.Sort();
            var cardValueTest = Cards.FirstOrDefault().Value + 1;

            for (int i = 1; i < Cards.Count -1 ; i++)
            {
                if (Cards[i].Value != cardValueTest)
                    return false;
                cardValueTest++;
            }

            return IsFlush();
        }

        private bool IsFlush()
        {
            foreach (Card card in Cards)
            {
                if (card.Suit != Cards.First().Suit)
                    return false;
            }

            return true;
        }
    }
}