using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.IO;
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

        private bool running; 

        #region Singleton
        private static TcpServer s_Instance = null;
        private bool _notConnected;

        public static TcpServer Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    s_Instance = new TcpServer();
                }
                return s_Instance;
            }
        }

       

        #endregion
        private TcpServer()
        {
            running = false;
            _notConnected = true;
        }



        public void Start(FlightBoardModel flightBoard,bool shouldStop)
        {
            if (! running) { 
                ISettingsModel app = ApplicationSettingsModel.Instance;
                //IPEndPoint ep = new IPEndPoint(IPAddress.Parse(app.FlightServerIP), app.FlightInfoPort);
                //TcpListener listener = new TcpListener(ep);
                //listener.Start();
                //Console.WriteLine("Waiting for a client");
                //TcpClient client = listener.AcceptTcpClient();
                //Console.WriteLine("Client connected");

                

                //connect to the simulator
                TcpListener server = new TcpListener(IPAddress.Parse(app.FlightServerIP), app.FlightInfoPort);
                
                server.Start();

                //wait till we have a connection
                TcpClient client = server.AcceptTcpClient();
                _notConnected = false;
                NetworkStream stream = client.GetStream();

                while (!shouldStop)
                {
                    byte[] buffer = new byte[client.ReceiveBufferSize];
                    int bytesRead = stream.Read(buffer, 0, client.ReceiveBufferSize);
                    string received = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                    Console.WriteLine("Received from client:" + received);

                    
                    string[] values = received.Split(',');
                    double x = Convert.ToDouble(values[0]);
                    double y = Convert.ToDouble(values[1]);
                    flightBoard.Lon = x;
                    flightBoard.Lat = y;
                }
            }
            _notConnected = true;
        }

        public bool notConncted()
        {
            return _notConnected;
        }
    }
}
        


