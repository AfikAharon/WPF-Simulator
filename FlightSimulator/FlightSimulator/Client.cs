using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace FlightSimulator
{
    class Client
    {
        private TcpClient tcpClient;
        private bool stillSending;
        private String[] listOfCommands;

        public Client() {
            tcpClient = new TcpClient();
            tcpClient.Connect("127.0.0.1", 5402);
            stillSending = false;
        }

        public void sendCommands()
        {
            stillSending = true;
            NetworkStream stream = tcpClient.GetStream();
            ASCIIEncoding encoding = new ASCIIEncoding();
            foreach (string com in listOfCommands)
            {
                byte[] tempBuffer = encoding.GetBytes(com + "\r\n");
                stream.Write(tempBuffer, 0, tempBuffer.Length);
                stream.Flush();
                System.Threading.Thread.Sleep(1000);
            }
            stillSending = false;
        }


        public void setListOfCommands(string[] commands)
        {
            listOfCommands = commands;
        }

        public bool getIfStillSending()
        {
            return stillSending;
        }
    }


}
