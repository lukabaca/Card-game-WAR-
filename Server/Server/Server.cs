using System;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using gameSpace;
using System.Runtime.Serialization;
using System.Net;
using System.Threading;

namespace server
{
    class Server
    {
        private int serverPort;
        private IPAddress serverAddr;

        private TcpListener serverSocket;

        private CustomFormatter customFormatter;

        private Boolean isRunning;



        public Server(String serverAddress, int serverPort)
        {
            this.serverPort = serverPort;
            this.serverAddr = IPAddress.Parse(serverAddress);

            this.serverSocket = new TcpListener(serverAddr, serverPort);
            this.serverSocket.Start();

            this.isRunning = true;
            this.customFormatter = new CustomFormatter();

            Console.WriteLine("Server is working at port: " + serverPort);

           

            waitForClients();
        }

        private Deck initDecks()
        {
            Deck deck = new Deck();


            deck.printDeck(Deck.GameDeck);
            deck.shuffleGameDeck();
            deck.initPlayersDecks();

            deck.printDeck(deck.ServerDeck);
            deck.printDeck(deck.ClientDeck);

            return deck;
        }

        private void writeToFile(Deck file)
        {
           

        }

        private void waitForClients()
        {


            while (isRunning)
            {
                Console.WriteLine("Server is waiting for clients...");
                TcpClient client = serverSocket.AcceptTcpClient();
                Console.WriteLine("Client was found: ");

                Thread thread = new Thread(() => handleClient(client));

                thread.Start();

            }


            serverSocket.Stop();
        }

        private void handleClient(TcpClient client)
        {
            Game game = new Game();
            


            Deck deck = initDecks();
            TcpClient newClient = client;
            NetworkStream ntwStream = client.GetStream();

            game.loadDeck(deck.ServerDeck);
            game.printCurrentDeck();
            game.printWonCardsDeck();
            customFormatter.sendDeck(ntwStream, deck);
            



            /*
            //TcpClient newClient = client;

            NetworkStream ntwStream = client.GetStream();
            FileTransfer file = formatter.deserialize(ntwStream);

            if (file != null)
            {
                writeToFile(file);
            }
            */
        }


    }
}
