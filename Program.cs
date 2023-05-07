using System;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Dealer dealer = new Dealer();
            int playerScore = 0;

            Console.WriteLine("Welcome to Marshall's Blackjack!");

            while (true)
            {
                // shuffle deck
                deck.Shuffle();

                // deal cards
                dealer.ClearHand();
                dealer.DealCard(deck.DrawCard());
                dealer.DealCard(deck.DrawCard());

                playerScore = 0;
                playerScore += deck.DrawCard().GetValue();
                playerScore += deck.DrawCard().GetValue();

                // show cards
                dealer.ShowHand();
                Console.WriteLine($"Your score: {playerScore}");

                // player's turn
                while (playerScore < 21)
                {
                    Console.Write("Do you want to hit? (y/n): ");
                    string? input = Console.ReadLine();
                    if (input == "y")
                    {
                        Card card = deck.DrawCard();
                        Console.WriteLine($"You drew {card}");
                        playerScore += card.GetValue();
                        Console.WriteLine($"Your score: {playerScore}");
                    }
                    else
                    {
                        break;
                    }
                }

                // dealer's turn
                while (dealer.ShouldHit())
                {
                    Card card = deck.DrawCard();
                    Console.WriteLine($"Dealer drew {card}");
                    dealer.DealCard(card);
                }

                // show result
                dealer.ShowHand();
                Console.WriteLine($"Dealer's score: {dealer.GetHandValue()}");

                if (playerScore > 21 || dealer.GetHandValue() > playerScore && dealer.GetHandValue() <= 21)
                {
                    Console.WriteLine("Dealer Wins!");
                }
                else if (dealer.GetHandValue() > 21 || playerScore > dealer.GetHandValue())
                {
                    Console.WriteLine("You Win!");
                }
                else
                {
                    Console.WriteLine("It's a Tie!");
                }

                // ask to play again
                Console.Write("Do you want to play again? (y/n): ");
                string? playAgain = Console.ReadLine();
                if (playAgain != "y")
                {
                    break;
                }
            }

            Console.WriteLine("Thanks for playing!");
        }
    }
}