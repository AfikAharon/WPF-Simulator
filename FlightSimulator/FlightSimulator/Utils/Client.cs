using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using FlightSimulator.Model;
using FlightSimulator.Model.Interface;



namespace FlightSimulator
{
    class Client
    {
        private TcpClient tcpClient;
        private String[] listOfCommands;
        ISettingsModel portAndIp;

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
        private Client() {
            tcpClient = new TcpClient();
            portAndIp = ApplicationSettingsModel.Instance;
            //tcpClient.Connect(portAndIp.FlightServerIP, portAndIp.FlightCommandPort);
        }

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

        public void setListOfCommands(string[] commands)
        {
            listOfCommands = commands;
        }

        public void establishConnection()
        {
            if (tcpClient.Connected)
            {
                tcpClient.Close();
            }
            tcpClient.Connect(portAndIp.FlightServerIP, portAndIp.FlightCommandPort);
        }
    }
}
