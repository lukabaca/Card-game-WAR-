using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gameSpace;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            String localAddress = "127.0.0.1";
            Client client = new Client();
            if (!client.connectToServer(localAddress, 5000))
            {
                Console.ReadLine();
                return;
            }

            Game game = new Game();

            Deck deck = client.receiveDeck();
            if(deck == null)
            {
                return;
            }

            game.loadDeck(deck.ClientDeck);

            game.printCurrentDeck();
            game.printWonCardsDeck();

            while(true)
            {
                String myCard = game.getCardFromTop();
                Move move = new Move(myCard);

                client.sendMove(move);

                Move opponentMove = client.receiveMove();
                String opponentCard = opponentMove.Card;

                Console.WriteLine("Battle: " + myCard + " vs " + opponentCard);

                game.cardBattle(myCard, opponentCard);

                Console.WriteLine("Nacisnij cos by wykonac nastepny ruch");
                Console.ReadLine();
            }

            Console.ReadLine();
        }
    }
}
