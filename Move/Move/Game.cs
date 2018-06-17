using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Move
{
    class Game
    {
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

        //do kupki odkladam karte, ktora wylozylem i pokonala przeciwnika oraz karte przeciwnika
        public void addCardToWonCardsDeck(String myCard, String opponentCard)
        {
            wonCardsDeck.Add(myCard);
            wonCardsDeck.Add(opponentCard);
        }
        public void removeCardFromDeck(String card)
        {
            currentDeck.Remove(card);
        }

        public void loadDeck(List<String> deck)
        {
            for (int i = 0; i < deck.Count; i++)
            {
                String card = deck.ElementAt(i);
                currentDeck.Add(card);
            }

    }
}
