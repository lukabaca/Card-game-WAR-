using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

using System.Text;
using System.IO;

using gameSpace;
using System.Collections.Generic;

namespace server
{
    class Server
    {
        private int serverPort;
        private IPAddress serverAddr;

        private TcpListener serverSocket;

        private CustomFormatter formatter;

        private Boolean isRunning;

        public Server(String serverAddress, int serverPort)
        {
            this.serverPort = serverPort;
            this.serverAddr = IPAddress.Parse(serverAddress);

            this.serverSocket = new TcpListener(serverAddr, serverPort);
            this.serverSocket.Start();

            this.isRunning = true;
            this.formatter = new CustomFormatter();

            Console.WriteLine("Server is working at port: " + serverPort);

            initDecks();

            waitForClients();
        }

        private void initDecks()
        {
            Deck deck = new Deck();


            deck.printDeck(Deck.GameDeck);
            deck.shuffleGameDeck();
            deck.initPlayersDecks();

            deck.printDeck(deck.ServerDeck);
            deck.printDeck(deck.ClientDeck);
        }

        private void writeToFile(Deck file)
        {
            /*
            try
            {
                System.IO.File.WriteAllBytes(file.FileName, file.File);

                Console.WriteLine("Utworzono plik o nazwie: " + file.FileName);
            }
            catch (Exception e)
            {
                Console.WriteLine("Writing to the file was not succesful");
                Console.WriteLine(e);
            }
            */

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
