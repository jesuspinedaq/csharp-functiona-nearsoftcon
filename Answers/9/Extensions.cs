using System.Collections.Generic;
using System.Linq;

namespace Poker.Library
{
    public static class Extensions
    {
        public static  Dictionary<CardValue, int> ToDicctionaryAndQuantity(this IEnumerable<Card> @value)
        {
            var CardQuantity = new Dictionary<CardValue, int>();

            foreach (Card card in @value)
            {
                if (CardQuantity.Keys.Contains(card.Value))
                    CardQuantity[card.Value] += 1;
                else
                    CardQuantity[card.Value] = 1;
            }

            return CardQuantity;
        }
    }
}