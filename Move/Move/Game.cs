using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameSpace
{
    public class Game
    {
        private static Dictionary<String, int> comparingMap = new Dictionary<string, int>()
        {
         {"2_PIK", 2}, { "3_PIK",3 }, { "4_PIK",4 }, { "5_PIK", 5 }, { "6_PIK", 6 }, { "7_PIK", 7 }, { "8_PIK",8 }, { "9_PIK",9 }, { "10_PIK",10 }, { "J_PIK", 11 }, { "D_PIK", 12 }, { "K_PIK", 13 }, { "A_PIK", 14 },
         {"2_KIER", 2}, { "3_KIER",3 }, { "4_KIER",4 }, { "5_KIER", 5 }, { "6_KIER", 6 }, { "7_KIER", 7 }, { "8_KIER",8 }, { "9_KIER",9 }, { "10_KIER",10 }, { "J_KIER", 11 }, { "D_KIER", 12 }, { "K_KIER", 13 }, { "A_KIER", 14 }


        };


        private List<String> currentDeck;
        //kupka kart, ktore wygralismy
        private List<String> wonCardsDeck;

        private Boolean isPlaying;

        public Game()
        {
            currentDeck = new List<String>();
            wonCardsDeck = new List<String>();
            isPlaying = true;
        }

        public void cardBattle(String myCard, String opponentCard)
        {
            int myCardValue = comparingMap[myCard];
            int opponentCardValue = comparingMap[myCard];


            if(myCardValue > opponentCardValue)
            {
                //dodaje moja karte, ktora pokonalem przeciwnika i karte przeciwnika do 2 listy, "kupki" kart
                currentDeck.Remove(myCard);

                wonCardsDeck.Add(myCard);
                wonCardsDeck.Add(opponentCard);
            }

            if(myCardValue < opponentCardValue)
            {
                //usuwam karte swoja
                currentDeck.Remove(myCard);
            }

            if(myCardValue == opponentCardValue)
            {
                //przypadek wojny
            }


        }


        private Boolean isCurrentDeckEmpty()
        {
            if(currentDeck.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private Boolean iswonCardsDeckyEmpty()
        {
            if (wonCardsDeck.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        //do kupki odkladam karte, ktora wylozylem i pokonala przeciwnika oraz karte przeciwnika
        public void addCardToWonCardsDeck(String myCard, String opponentCard)
        {
            wonCardsDeck.Add(myCard);
            wonCardsDeck.Add(opponentCard);
        }
        public void removeCardFromDeck(String card)
        {
            if (!isCurrentDeckEmpty())
            {
                currentDeck.Remove(card);
            }
            else if(!iswonCardsDeckyEmpty())
            {

                loadDeck(wonCardsDeck);
            }
            //przypadek gry przegrywanm
            else
            {
                isPlaying = false;
            }

        }

        public void loadDeck(List<String> deck)
        {
            for (int i = 0; i < deck.Count; i++)
            {
                String card = deck.ElementAt(i);
                currentDeck.Add(card);
            }

        }

        public void printCurrentDeck()
        {
            Console.WriteLine("Current deck: ");
            foreach (String card in currentDeck)
            {
                Console.WriteLine(card + " ");
            }
            Console.WriteLine("###########################");
        }

        public void printWonCardsDeck()
        {
            Console.WriteLine("Deck with won cards: ");
            foreach (String card in wonCardsDeck)
            {
                Console.WriteLine(card + " ");
            }
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@");
        }
    }
}
