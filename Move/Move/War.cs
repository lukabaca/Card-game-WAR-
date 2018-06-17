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

        public void addCardsToDecks(String serverSideCard, String clientSideCard)
        {
            myCardDeck.Add(serverSideCard);
            opponentCardDeck.Add(clientSideCard);
        }

        public List<string> ServerSideDeck
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

        public List<string> ClientSideDeck
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
