using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Blackjack
{
    class Program
    {

        static List<Card> RandomDeck = new List<Card>();
 
         static List<Card> AddCardTo(List<Card> hand)
         {
             hand.Add(RandomDeck[0]);
             RandomDeck.RemoveAt(0);
             return hand;
         }
 
         static void ShowHand(IEnumerable<Card> hand)
         {
             foreach (var card in hand)
             {
                 Console.WriteLine(card);
             }
         }
 
         static int HandTotal(List<Card> hand)
         {
             var total = 0;
             foreach (var card in hand)
             {
                 total += card.GetCardValue();
             }
             return total;
         }
 
         static void ShowHandTotal(List<Card> hand)
         {
             var total = HandTotal(hand);
             Console.WriteLine($"Your total is : {total}");
         }



        static void Main(string[] args)
        {
            var deck = new List<Card>();

            foreach (Rank r in Enum.GetValues(typeof(Rank)))
            {
                foreach (Suit s in Enum.GetValues(typeof(Suit)))
                {
                    deck.Add(new Card(s, r));
                }
            }

            //This sorts the deck. 'RandomDeck' is the deck that is sorted. The variable 'deck' stays unchanged.
            RandomDeck = deck.OrderBy(x => Guid.NewGuid()).ToList();

            var PlayersHand = new List<Card>();
            var ComputersHand = new List<Card>();

            PlayersHand = AddCardTo(PlayersHand);
            PlayersHand = AddCardTo(PlayersHand);
            ComputersHand = AddCardTo(ComputersHand);
            ComputersHand = AddCardTo(ComputersHand);

            ShowHand(new Card[9]);


            ShowHand(ComputersHand.Take(1));


            var stillPlaying = true;
            while (stillPlaying && HandTotal(PlayersHand) <= 21)
            {
                Console.WriteLine("Your Hand:");
                ShowHand(PlayersHand);
                ShowHandTotal(PlayersHand);
                Console.WriteLine();
                Console.WriteLine("[H]it or [S]tay?");
                var input = Console.ReadLine();
                if (input.ToLower() == "h")
                {
                    PlayersHand = AddCardTo(PlayersHand);
                }

                else if (input.ToLower() == "s")
                {
                    stillPlaying = false;
                }
            }

            Console.WriteLine($"You are done playing with a {HandTotal(PlayersHand)}");

            Console.WriteLine("Dealers Turn");
            ShowHand(ComputersHand);
            ShowHandTotal(ComputersHand);
            while (HandTotal(ComputersHand) < 16)
            {
                ComputersHand = AddCardTo(ComputersHand);
                Console.WriteLine("Dealers New Hand:");
                ShowHand(ComputersHand);
            }
            Console.WriteLine();


            Console.WriteLine($"Dealer has {HandTotal(ComputersHand)}");

            Console.WriteLine($"Player has {HandTotal(PlayersHand)}");

            

            if(HandTotal(ComputersHand) > 21 && HandTotal(PlayersHand) <= 21)
            {
                Console.WriteLine($"Dealer bust, you won!");
            }

            if((HandTotal(ComputersHand) > HandTotal(PlayersHand) && HandTotal(ComputersHand) <= 21))
            {
                Console.WriteLine($"Dealer won");
            }

            if ((HandTotal(ComputersHand) < HandTotal(PlayersHand) && HandTotal(PlayersHand) <= 21))
            {
                Console.WriteLine($"You won!");
            }

            if (HandTotal(PlayersHand) > 21 && HandTotal(ComputersHand) <= 21)
            {
                Console.WriteLine($"You bust, dealer won");
            }

            
            Console.ReadLine();
        }
    }
}
           
        


    




