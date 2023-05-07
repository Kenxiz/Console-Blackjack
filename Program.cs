using System;
using System.Threading;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            // Customizing the Terminal
            Console.Title = "Blackjack | Created by Marshall (Spectic/Kenxiz)";
            Console.ForegroundColor = System.ConsoleColor.Green;

            // Deck
            Deck deck = new Deck();
            Dealer dealer = new Dealer();
            int playerScore = 0;

            Console.WriteLine("Welcome to Marshall's Blackjack! We will begin in 5 seconds!\n");

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
                Console.WriteLine($"Your score: {playerScore}\n");

                // player's turn
                while (playerScore < 21)
                {
                    Console.Write("Do you want to hit? (y/n): ");
                    string? input = Console.ReadLine();
                    if (input == "y")
                    {
                        Card card = deck.DrawCard();
                        Console.WriteLine($"You drew {card}\n");
                        playerScore += card.GetValue();
                        Console.WriteLine($"Your score: {playerScore}\n");
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
                    Console.WriteLine($"Dealer drew {card}\n");
                    dealer.DealCard(card);
                }
                // show result
                dealer.ShowHand();
                Console.WriteLine($"Dealer's score: {dealer.GetHandValue()}\n");

                if (playerScore > 21 || dealer.GetHandValue() > playerScore && dealer.GetHandValue() <= 21)
                {
                    Console.WriteLine("Dealer Wins!\n");
                }
                else if (dealer.GetHandValue() > 21 || playerScore > dealer.GetHandValue())
                {
                    Console.WriteLine("You Win! (Continuing in 5 seconds!)\n");
                }
                else
                {
                    Console.WriteLine("It's a Tie! (Continuing in 5 seconds!)\n");
                }

                // ask to play again
                Console.Write("Do you want to play again? (y/n): \n");
                string? playAgain = Console.ReadLine();
                if (playAgain != "y")
                {
                    break;
                }
            }

            Console.WriteLine("Thanks for playing!\n");
        }
    }
}