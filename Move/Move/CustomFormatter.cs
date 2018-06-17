using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace gameSpace
{
    public class CustomFormatter
    {
        private IFormatter formater;

        public CustomFormatter()
        {
            this.formater = new BinaryFormatter();
        }

        public Move receiveMove(NetworkStream networkStream)
        {
            Move move = null;
            try
            {
                move = (Move)formater.Deserialize(networkStream);
                return move;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        public Boolean sendMove(NetworkStream networkStream, Move move)
        {

            try
            {
                formater.Serialize(networkStream, move);
                Console.WriteLine("Move: " + move.Card);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Sending move was not successful");
                return false;
            }

        }

        public Deck receiveDeck(NetworkStream networkStream)
        {
            Deck deck = null;
            try
            {
                deck = (Deck)formater.Deserialize(networkStream);
                return deck;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        public Boolean sendDeck(NetworkStream networkStream, Deck deck)
        {

            try
            {
                formater.Serialize(networkStream, deck);
                Console.WriteLine("Deck has been sent");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Sending deck was not successful");
                return false;
            }

        }

    }
}
