using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameSpace
{
    [Serializable]
    class War
    {
        private List<String> myCardDeck;
        private List<String> opponentCardDeck;

        

        public War()
        {
            myCardDeck = new List<String>();
            opponentCardDeck = new List<String>();
        }

        public void clearDecks()
        {
            myCardDeck.Clear();
            opponentCardDeck.Clear();
        }

        public void addCardsToDecks(String myCard, String opponentCard)
        {


            myCardDeck.Add(myCard);
            opponentCardDeck.Add(opponentCard);
        }

        public List<string> MyCardDeck
        {
            get
            {
                return myCardDeck;
            }

            set
            {
                myCardDeck = value;
            }
        }

        public List<string> OpponentCardDeck
        {
            get
            {
                return opponentCardDeck;
            }

            set
            {
                opponentCardDeck = value;
            }
        }
    }
}
