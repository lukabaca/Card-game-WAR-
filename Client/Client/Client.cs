using System;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using gameSpace;
using System.Runtime.Serialization;

namespace client
{
    class Client
    {
        private TcpClient clientSocket;
        private CustomFormatter customFormatter;
        private NetworkStream ntwStream;
        public Client()
        {
            clientSocket = new TcpClient();
            customFormatter = new CustomFormatter();
            
        }

        public Boolean connectToServer(String serverIpAddress, int portNumber)
        {
            try
            {
                clientSocket.Connect(serverIpAddress, portNumber);
                ntwStream = clientSocket.GetStream();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured while connecting to server");
                return false;
            }
        }

        public Deck receiveDeck()
        {
            
            
            Deck deck = customFormatter.receiveDeck(ntwStream);
            return deck;
        }

        public Move receiveMove()
        {
            Move move = customFormatter.receiveMove(ntwStream);
            return move;
        }

        public void sendMove(Move move)
        {
            customFormatter.sendMove(ntwStream, move);
        }

        public TcpClient SocketForServer
        {
            get
            {
                return clientSocket;
            }

            set
            {
                clientSocket = value;
            }
        }
    }
}
