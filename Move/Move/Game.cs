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
         {"2", 2}, { "3",3 }, { "4",4 }, { "5", 5 },
         { "6", 6 }, { "7", 7 }, { "8",8 }, { "9",9 },
         { "10",10 }, { "J", 11 }, { "D", 12 }, { "K", 13 },
         { "A", 14 },
         
        };


        private List<String> currentDeck;
        //kupka kart, ktore wygralismy
        private List<String> wonCardsDeck;

        private Boolean isPlaying;

        private Boolean isWar;

        

        public Game()
        {
            currentDeck = new List<String>();
            wonCardsDeck = new List<String>();
            isPlaying = true;
            isWar = false;
        }

        public String getCardFromTop()
        {
            int lastElement = currentDeck.Count - 1;
            return currentDeck.ElementAt(lastElement);
        }

        public String changeCardFormat(String card)
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            foreach (char sign in card)
            {
                
                if (sign.Equals('_'))
                {
                    break;
                }
                else
                {
                    
                    stringBuilder.Append(sign);
                }
            }

            String cardFormatted = stringBuilder.ToString();
            return cardFormatted;

        }

        public void cardBattle(String myCard, String opponentCard)
        {
            String myCardFormatted = changeCardFormat(myCard);
            String opponentCardFormatted = changeCardFormat(opponentCard);

            int myCardValue = comparingMap[myCardFormatted];
            int opponentCardValue = comparingMap[opponentCardFormatted];

            //Console.WriteLine("My card value: " + myCardValue);
            //Console.WriteLine("Opponent card value: " + opponentCardValue);

            if (myCardValue > opponentCardValue)
            {
                //dodaje moja karte, ktora pokonalem przeciwnika i karte przeciwnika do 2 listy, "kupki" kart
                Console.WriteLine(myCard + " > " + opponentCard);

                currentDeck.Remove(myCard);

                wonCardsDeck.Add(myCard);
                wonCardsDeck.Add(opponentCard);
            }

            if(myCardValue < opponentCardValue)
            {
                Console.WriteLine(myCard + " < " + opponentCard);
                //usuwam karte swoja
                currentDeck.Remove(myCard);
            }

            if(myCardValue == opponentCardValue)
            {
                isWar = true;
                Console.WriteLine("JEST WOJNA");
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

        public bool IsPlaying
        {
            get
            {
                return isPlaying;
            }

            set
            {
                isPlaying = value;
            }
        }

        public bool IsWar
        {
            get
            {
                return isWar;
            }

            set
            {
                isWar = value;
            }
        }
    }
}
