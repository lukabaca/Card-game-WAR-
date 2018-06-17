using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            while(true)
            {




                Console.ReadLine();
            }

            Console.ReadLine();
        }
    }
}
