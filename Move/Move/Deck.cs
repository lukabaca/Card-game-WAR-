using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameSpace
{
    public class Deck
    {

        //K - kier, P - pik, T - trefl, 
        private static List<String> gameDeck = new List<String>()

        {"2_PIK", "3_PIK", "4_PIK", "5_PIK", "6_PIK", "7_PIK", "8_PIK", "9_PIK", "10_PIK", "J_PIK", "D_PIK", "K_PIK", "A_PIK",
         "2_KIER", "3_KIER", "4_KIER", "5_KIER", "6_KIER", "7_KIER", "8_KIER", "9_KIER", "10_KIER", "J_KIER", "D_KIER", "K_KIER", "A_KIER"

        };

        private List<String> serverDeck;

        private List<String> clientDeck;

        public Deck()
        {
            serverDeck = new List<String>();
            clientDeck = new List<String>();
        }

        public void shuffleGameDeck()
        {
            var rand = new Random();

            GameDeck = GameDeck.OrderBy(x => rand.Next()).ToList();

            //printDeck();
        }

        public void initPlayersDecks()
        {
            for(int i = 0; i < GameDeck.Count; i++)
            {
                String card = GameDeck.ElementAt(i);
                if (i < 13)
                {
                    serverDeck.Add(card);
                }
                else
                {
                    clientDeck.Add(card);
                }
            }
        }

        public void printDeck(List<String> deck)
        {
            foreach(String card in deck)
            {
                Console.WriteLine(card + " ");
            }
            Console.WriteLine("------------------------------");
        }



        public List<string> ServerDeck
        {
            get
            {
                return serverDeck;
            }

            set
            {
                serverDeck = value;
            }
        }

        public List<string> ClientDeck
        {
            get
            {
                return clientDeck;
            }

            set
            {
                clientDeck = value;
            }
        }

        public static List<string> GameDeck
        {
            get
            {
                return gameDeck;
            }

            set
            {
                gameDeck = value;
            }
        }
    }
}
