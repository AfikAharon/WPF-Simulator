using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace FlightSimulator.Model
{
    public class TcpServer
    {
        private IPEndPoint ep;
        TcpListener listener;
        private CommandHandler handler;
        private bool isListening;


        public TcpServer(CommandHandler commandHandler, int port)
        {
            handler = commandHandler;
            isListening = false;
            ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
            listener = new TcpListener(ep);

        }

   
        

        public void startServer()
        {
            
            isListening = true;
            Console.WriteLine("Waiting for client connections...");

            /*
            Thread thread = new Thread(() => {
                while (isListening)
                {
                    listener.Start();

                }
            }
            */

        }
    }
}
        


