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
        private volatile bool running;
        private volatile bool _shouldStop;
        private bool firstData;
        private int counter;
        private volatile Thread _currentThread;

        #region Singleton
        private static TcpServer s_Instance = null;
        volatile private bool _notConnected;

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
        /*
         * Constructs a new TcpServer
         */
        private TcpServer()
        {
            running = false;
            _shouldStop = false;
            _notConnected = true;
            _currentThread = null;
            firstData = false;
            counter = 0;

        }

        /*
         * ShouldStop property, sets and returns the value
         */
        public bool ShouldStop
        {
            get { return _shouldStop; }
            set { _shouldStop = value; }
        }

        /*
         * NotConnected property, sets and returns the value
         */
        public bool NotConnected
        {
            get { return _notConnected; }
            set { _notConnected = value; }
        }

        /*
         * GetCurrentThread property, sets and returns the value
         */
        public Thread GetCurrentThread
        {
            get { return _currentThread; }
            set { this._currentThread = value; }
        } 

        /*
         * The function starts the server, waits till we have connection from client, then starts reading the data
         * and sends the Lon and Lat values to the given fligtBoard.
         */
        public void Start(FlightBoardModel flightBoard)
        {
            GetCurrentThread = Thread.CurrentThread;
            if (! running) { 
                ISettingsModel app = ApplicationSettingsModel.Instance;
                //connect to the simulator
                TcpListener server = new TcpListener(IPAddress.Parse(app.FlightServerIP), app.FlightInfoPort);
                
                server.Start();

                //wait till we have a connection
                TcpClient client = server.AcceptTcpClient();
                NotConnected = false;
                NetworkStream stream = client.GetStream();

                while (!ShouldStop)
                {
                    byte[] buffer = new byte[client.ReceiveBufferSize];
                    int bytesRead = stream.Read(buffer, 0, client.ReceiveBufferSize);
                    string received = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                    Console.WriteLine("Received from client:" + received);
                    if (firstData)
                    {
                        string[] values = received.Split(',');
                        double x = Convert.ToDouble(values[0]);
                        double y = Convert.ToDouble(values[1]);
                        flightBoard.Lon = x;
                        flightBoard.Lat = y;
                        System.Console.WriteLine(ShouldStop);
                    } else
                    {
                        if (counter == 2)
                        {
                            firstData = true;
                        } else
                        {
                            counter++;
                        }
                    }
                    
                    
                }
            }

            NotConnected = true;
        }
    }
}
        


