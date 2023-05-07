using System;
using System.Collections.Generic;

namespace Blackjack
{
    enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    enum Rank
    {
        Ace = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    class Card
    {
        public Suit Suit { get; }
        public Rank Rank { get; }

        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public int GetValue()
        {
            if (Rank == Rank.Ace)
            {
                return 1;
            }
            else if (Rank == Rank.Jack || Rank == Rank.Queen || Rank == Rank.King)
            {
                return 10;
            }
            else
            {
                return (int)Rank;
            }
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
    }

    class Deck
    {
        private List<Card> cards;
        private Random random;

        public Deck()
        {
            cards = new List<Card>();
            random = new Random();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    Card card = new Card(suit, rank);
                    cards.Add(card);
                }
            }
        }

        public void Shuffle()
        {
            for (int i = cards.Count - 1; i >= 1; i--) 
            {
                int j = random.Next(i + 1);
                Card temp = cards[j];
                cards[j] = cards[i];
                cards[i] = temp;
            }
        }

        public Card DrawCard()
        {
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
    }
}
// End