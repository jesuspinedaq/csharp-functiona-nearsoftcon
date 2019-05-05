using System;
using Poker.Library;
using Xunit;

namespace Poker.Test
{
    public class CardTest
    {
        [Fact]
        public void CanDescribeCard()
        {
            var card = new Card(CardValue.Ace, CardSuit.Spades);

            Assert.Equal("Ace of Spades", card.ToString());
        }

    }
}