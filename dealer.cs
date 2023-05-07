using System;
using System.Collections.Generic;

namespace Blackjack
{
    class Dealer
    {
        private List<Card> hand;

        public Dealer()
        {
            hand = new List<Card>();
        }

        public void DealCard(Card card)
        {
            hand.Add(card);
        }

        public int GetHandValue()
        {
            int handValue = 0;
            bool hasAce = false;

            foreach (Card card in hand)
            {
                if (card.Rank == Rank.Ace)
                {
                    hasAce = true;
                }

                handValue += card.GetValue();
            }

            if (hasAce && handValue <= 11)
            {
                handValue += 10;
            }

            return handValue;
        }

        public bool ShouldHit()
        {
            return GetHandValue() <= 16;
        }

        public void ShowHand()
        {
            Console.WriteLine("Dealer's hand:");
            foreach (Card card in hand)
            {
                Console.WriteLine(card);
            }
        }

        public void ClearHand()
        {
            hand.Clear();
        }
    }
}
// End