using FlightSimulator.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    public class FlightBoardModel : IModelNotify
    {

        private SettingsWindow settingsWindow;
        private double _lon;
        private double _lat;
        private bool windowOpen;

        /*
         * Constructs a new FlightBoardModel
         */
        public FlightBoardModel()
        {
            windowOpen = false;
            settingsWindow = null;
        }

        /*
         * Creates a new TcpServer instance, Client instance, creating a new thread which runs the tcpServer.Start()
         * function and establishing a connection.
         */ 
        public void connect()
        {
            TcpServer tcpServer = TcpServer.Instance;
            if (tcpServer.NotConnected)
            {
                Thread serverThread = new Thread(() => tcpServer.Start(this));
                serverThread.Start();
                // backup  the thread for kill in the main window
                //tcpServer.GetCurrentThread = serverThread;
            }
            Client client = Client.Instance;
            client.establishConnection();
        }

        /*
         * Lon property, returns the value and sets the value
         */
        public double Lon
        {
            get
            {
                return _lon;
            }
            set
            {
                this._lon = value;
                NotifyPropertyChanged("Lon");
            }
        }

        /*
         * Lat property, returns the value and sets the value
         */
        public double Lat
        {
            get
            {
                return _lat;
            }
            set
            {
                this._lat = value;
                NotifyPropertyChanged("Lat");
            }
        }

        /*
         * Creates a new instance of settingsWindow and shows the window
         */
        public void showSetting()
        {
            if (settingsWindow == null || !settingsWindow.IsLoaded)
            {
                settingsWindow = new SettingsWindow();
                settingsWindow.Show();
            }
            
        }
        
    }
}
