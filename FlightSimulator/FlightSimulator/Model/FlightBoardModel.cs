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
        private bool shouldStop;
        private bool windowOpen;


        public FlightBoardModel()
        {
            windowOpen = false;
            settingsWindow = null;
            this.shouldStop = false;
        }


        public void connect()
        {
            TcpServer tcpServer = TcpServer.Instance;
            Thread serverThread = new Thread(() => tcpServer.Start(this, shouldStop));
            serverThread.Start();
            Client client = Client.Instance;
            client.establishConnection();
        }

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
