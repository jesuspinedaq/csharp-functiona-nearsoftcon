using System;
using System.Linq;
using Poker.Library;
using Xunit;

namespace Poker.Test
{
    public class HandTest
    {
        [Fact]
        public void CanCreateHand()
        {
            var hand = new Hand();
            Assert.True(hand.Cards.Count == 0);
        }
        
        [Fact]
        public void CanHandDrawCard()
        {
            var card = new Card(CardValue.Ace, CardSuit.Spades);
            var hand = new Hand();

            hand.Draw(card);

            Assert.Equal(hand.Cards.First(), card);
        }

    }
}