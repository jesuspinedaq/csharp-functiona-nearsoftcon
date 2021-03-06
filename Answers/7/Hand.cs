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

        private bool IsFullHouse()
        {
            Cards.Sort();
            
            /* ------------------------------------------------------
                Check for: x x x y y
            ------------------------------------------------------- */
            var a1 = Cards[0].Value == Cards[1].Value &&
                Cards[1].Value == Cards[2].Value &&
                Cards[3].Value == Cards[4].Value;

            /* ------------------------------------------------------
                Check for: x x y y y
            ------------------------------------------------------- */
            var a2 = Cards[0].Value == Cards[1].Value &&
                Cards[2].Value == Cards[3].Value &&
                Cards[3].Value == Cards[4].Value;

            return (a1 || a2);
        }

        private bool IsFourOfAKind()
        {
            Cards.Sort();

            /* ------------------------------------------------------
                Check for: fisrst 4 cards of the same rank 
            ------------------------------------------------------- */
            var a1 = Cards[0].Value == Cards[1].Value &&
            Cards[1].Value == Cards[2].Value &&
                Cards[2].Value == Cards[3].Value;
            /* ------------------------------------------------------
                Check for: fisrst 4 cards of the same rank 
            ------------------------------------------------------- */
            var a2 = Cards[1].Value == Cards[2].Value &&
            Cards[2].Value == Cards[3].Value &&
            Cards[3].Value == Cards[4].Value;

            return (a1 || a2);
        }

        private bool IsThreeOfAKind()
        {
            Cards.Sort();
            /* ------------------------------------------------------
                Check for: x x x a b
            ------------------------------------------------------- */
            var a1 = Cards[0].Value == Cards[1].Value &&
               Cards[1].Value == Cards[2].Value;
            /* ------------------------------------------------------
                Check for: a x x x b
            ------------------------------------------------------- */
            var a2 = Cards[1].Value == Cards[2].Value &&
               Cards[2].Value == Cards[3].Value;
            /* ------------------------------------------------------
                Check for: a b x x x
            ------------------------------------------------------- */
            var a3 = Cards[2].Value == Cards[3].Value &&
               Cards[3].Value == Cards[4].Value;

            return (a1 || a2 || a3);
        }

        private bool IsPair()
        {
            Cards.Sort();
            /* --------------------------------
             Checking: a a x y z
            -------------------------------- */
            if (Cards[0].Value == Cards[1].Value)
            {
                return true;
            }
            /* --------------------------------
            Checking: x a a y z
            -------------------------------- */
            else if (Cards[1].Value == Cards[2].Value)
            {
                return true;
            }
            /* --------------------------------
            Checking: x y a a z
            -------------------------------- */
            else if (Cards[2].Value == Cards[3].Value)
            {
                return true;
            }
            /* --------------------------------
            Checking: x y z a a
            -------------------------------- */
            else if (Cards[3].Value == Cards[4].Value)
            {
                return true;
            }

            return false;
        }

        private bool IsRoyalFlush() => Cards.All(card => card.Value >= CardValue.Ten) && IsFlush();

        private bool IsFlush() => Cards.All(card => card.Suit == Cards.First().Suit);

    }
}