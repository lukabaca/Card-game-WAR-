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
         { "6", 6 }, { "7", 7 }
         
        };


        private List<String> currentDeck;
        //kupka kart, ktore wygralismy
        private List<String> wonCardsDeck;

        private Boolean isPlaying;

        private Boolean isWar;

        private War war;
        

        public Game()
        {
            currentDeck = new List<String>();
            wonCardsDeck = new List<String>();
            isPlaying = true;
            isWar = false;

            war = new War();
        }

        public String getCardFromTop()
        {
            /*
            int lastElement = -1;

            if (!isCurrentDeckEmpty())
            {
                lastElement = currentDeck.Count - 1;
                
            }
            else if (!iswonCardsDeckyEmpty())
            {
                loadDeck(wonCardsDeck);

                lastElement = currentDeck.Count - 1;                
            }
            */

            int lastElement = -1;

            if (!isCurrentDeckEmpty())
            {
                Console.WriteLine("current lsita nie jest pusta");
                lastElement = currentDeck.Count - 1;
            }
            else
            {
                Console.WriteLine("current lsita jest pusta");
                if (!iswonCardsDeckyEmpty())
                {
                    Console.WriteLine("won card deck nie jest pusta");
                    loadDeck(wonCardsDeck);
                    Console.WriteLine("CZYSZCZE wonCardsDeck");
                    resetWonCardsDeckk();

                    lastElement = currentDeck.Count - 1;
                }
                //jesli oba decki sa puste to znaczy ze przegralem
                else
                {
                    isPlaying = false;
                }
            }

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
        private void addCardsToWonCardsDeckFromWar(List<String> myWarCardDeck, List<String> opponentWarCarDeck)
        {
            foreach(String card in myWarCardDeck)
            {
                wonCardsDeck.Add(card);
            }

            foreach (String card in opponentWarCarDeck)
            {
                wonCardsDeck.Add(card);
            }
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

                if(isWar)
                {
                    removeCardFromDeck(myCard);

                    war.addCardsToDecks(myCard, opponentCard);

                    //tu musze dodac karty do kupki z puli wojny
                    addCardsToWonCardsDeckFromWar(war.MyCardDeck, war.OpponentCardDeck);


                    war.clearDecks();
                    isWar = false;
                }
                else
                {
                    removeCardFromDeck(myCard);

                    wonCardsDeck.Add(myCard);
                    wonCardsDeck.Add(opponentCard);
                }

                
            }

            if(myCardValue < opponentCardValue)
            {
                Console.WriteLine(myCard + " < " + opponentCard);

                if(isWar)
                {
                    removeCardFromDeck(myCard);

                    war.clearDecks();
                    isWar = false;
                }
                else
                {
                    removeCardFromDeck(myCard);
                }
            }

            if(myCardValue == opponentCardValue)
            {
                Console.WriteLine("JEST WOJNA");
                isWar = true;

                removeCardFromDeck(myCard);

                war.addCardsToDecks(myCard, opponentCard);
               
                //przypadek wojny
            }


        }
        //dodaje karty do puli wojny, te co sa 'ukryte'
        public void addCardsToWarBonus(String myCard, String opponentCard)
        {
            currentDeck.Remove(myCard);

            war.addCardsToDecks(myCard, opponentCard);
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
                Console.WriteLine("current lsita nie jest pusta");
                currentDeck.Remove(card);
            }
            else 
            {
                Console.WriteLine("current lsita jest pusta");
                if (!iswonCardsDeckyEmpty())
                {
                    Console.WriteLine("won card deck nie jest pusta");
                    loadDeck(wonCardsDeck);
                    Console.WriteLine("CZYSZCZE wonCardsDeck");
                    resetWonCardsDeckk();
                }
                //jesli oba decki sa puste to znaczy ze przegralem
                else
                {
                    isPlaying = false;
                }
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

        public void resetWonCardsDeckk()
        {
            wonCardsDeck.Clear();
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
