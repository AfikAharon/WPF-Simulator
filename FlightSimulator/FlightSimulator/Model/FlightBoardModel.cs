using FlightSimulator.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class FlightBoardModel : IModelNotify
    {

        private SettingsWindow settingsWindow;
        public FlightBoardModel()
        {
            settingsWindow = new SettingsWindow();
        }


        public void connect()
        {
            Client client = Client.Instance;
            client.establishConnection();
        }

        public void showSetting()
        {
            settingsWindow.Close();
            settingsWindow = new SettingsWindow();
            settingsWindow.Show();
        }
        
    }
}
