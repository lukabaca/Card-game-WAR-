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
            /*
            Game test = new Game();
            String temp = test.changeCardFormat("10_KIER");
            Console.WriteLine(temp);
            */
           
            
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


            //potem zrefaktoruj to
            Boolean bonus = false;
            while(true)
            {
               
                
                    Move move = null;
                    String myCard = game.getCardFromTop();

                    if(!game.IsPlaying)
                    {
                        Console.WriteLine("You lost");
                        Move finalMove = new Move(true);

                        client.sendMove(finalMove);
                        break;
                    }

                    if (bonus)
                    {
                        move = new Move(myCard, true, false);
                        bonus = false;
                    }
                    else
                    {
                        move = new Move(myCard);
                    }

                    client.sendMove(move);

                    Move opponentMove = client.receiveMove();
                    String opponentCard = opponentMove.Card;

                    if (opponentMove.IsGameFinished)
                    {
                        Console.WriteLine("You won!");
                        break;
                    }

                    Move myMove = null;

                    if (opponentMove.IsWar)
                    {
                        Console.WriteLine("Do puli wojny: " + myCard + " oraz przeciwnika " + opponentCard);
                        game.removeCardFromDeck(myCard);
                        game.addCardsToWarBonus(myCard, opponentCard);

                        myMove = new Move(myCard);

                    }
                    else
                    {
                        Console.WriteLine("Battle: " + myCard + " vs " + opponentCard);

                        game.cardBattle(myCard, opponentCard);

                        if (game.IsWar)
                        {
                            bonus = true;
                            //myMove = new Move(myCard, true);
                        }
                        else
                        {
                            //myMove = new Move(myCard);
                        }
                    }

                    //game.printWonCardsDeck();
                    game.printCurrentDeck();
                    game.printWonCardsDeck();
                    Console.WriteLine("Nacisnij cos by wykonac nastepny ruch");
                    Console.ReadLine();
                
                
            }
            
            Console.ReadLine();
        }
    }
}
