using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Move
{
    [Serializable]
    class War
    {
        private List<String> serverSideDeck;
        private List<String> clientSideDeck;

        

        public War()
        {
            serverSideDeck = new List<String>();
            clientSideDeck = new List<String>();
        }

        public void clearDecks()
        {
            serverSideDeck.Clear();
            clientSideDeck.Clear();
        }

        public void addCardsToDecks(String serverSideCard, String clientSideCard)
        {
            serverSideDeck.Add(serverSideCard);
            clientSideDeck.Add(clientSideCard);
        }

        public List<string> ServerSideDeck
        {
            get
            {
                return serverSideDeck;
            }

            set
            {
                serverSideDeck = value;
            }
        }

        public List<string> ClientSideDeck
        {
            get
            {
                return clientSideDeck;
            }

            set
            {
                clientSideDeck = value;
            }
        }
    }
}
