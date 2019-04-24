using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System.Threading;

namespace FlightSimulator
{
    class Client
    {
        private TcpClient tcpClient;
        private String[] listOfCommands;
        ISettingsModel portAndIp;
        private volatile Thread _currentThread;

        #region Singleton
        private static Client c_Instance = null;
        public static Client Instance
        {
            get
            {
                if (c_Instance == null)
                {
                    c_Instance = new Client();
                }
                return c_Instance;
            }
        }
        #endregion
        /*
         * Constructs a new Client
         */
        private Client() {
            tcpClient = new TcpClient();
            portAndIp = ApplicationSettingsModel.Instance;
            _currentThread = null;
        }

        /*
         * IsConnected property, returns the value
         */
        public bool IsConnected
        {
            get { return tcpClient.Connected; }
        }

        /*
         * GetCurrentThread property, returns the value , and sets value
         */
        public Thread GetCurrentThread
        {
            get { return _currentThread; }
            set { this._currentThread = value; }
        }

        /*
         * The function reads the commans given to him and then writes them, then sleeps for 2 seconds
         */
        public void handleCommand()
        {
            NetworkStream stream = tcpClient.GetStream();
            ASCIIEncoding encoding = new ASCIIEncoding();
            foreach (string com in listOfCommands)
            {
                byte[] tempBuffer = encoding.GetBytes(com + "\r\n");
                stream.Write(tempBuffer, 0, tempBuffer.Length);
                stream.Flush();
                System.Threading.Thread.Sleep(2000);
            }
        }

        /*/
         * The function sets the listOfCommands given by the parameter
         */
        public void setListOfCommands(string[] commands)
        {
            listOfCommands = commands;
        }

        /*
         * The function creates a new connection between the client and server, if was connected before, closes the connection
         */
        public void establishConnection()
        {
            if (tcpClient.Connected)
            {
                tcpClient.Close();
            }
            TcpServer tcpServer = TcpServer.Instance;
            while (tcpServer.NotConnected);
            tcpClient.Connect(portAndIp.FlightServerIP, portAndIp.FlightCommandPort);
        }
    }
}
