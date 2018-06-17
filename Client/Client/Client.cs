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
            
            NetworkStream ntwStream = clientSocket.GetStream();//to wydziel jako pole klasy client
            Deck deck = customFormatter.receiveDeck(ntwStream);
            return deck;
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
