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

        [Fact]
        public void CanGetHighCard()
        {
            var hand = new Hand();
            hand.Draw(new Card(CardValue.Seven, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
            hand.Draw(new Card(CardValue.Five, CardSuit.Hearts));
            hand.Draw(new Card(CardValue.King, CardSuit.Hearts));
            hand.Draw(new Card(CardValue.Two, CardSuit.Hearts));
            Assert.Equal(CardValue.King, hand.HighCard().Value);
        }
    }
}