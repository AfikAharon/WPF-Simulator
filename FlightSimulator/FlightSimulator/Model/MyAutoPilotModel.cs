using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FlightSimulator.Model
{
    class MyAutoPilotModel : IModelNotify
    {
        private String listOfCommands;
        //private Client client;
        private Brush background;

        public MyAutoPilotModel()
        {
            //client = Client.Instance;
            listOfCommands = "";
            Background_Change = Background_Change = Brushes.White;
        }

        public String ListOfCommands
        {
            get
            {
                return listOfCommands;
            }

            set
            {
                this.listOfCommands = value;
                NotifyPropertyChanged("TextBoxCommands");
            }
        }

        public Brush Background_Change
        {
            get
            {
                return background;
            }
            set
            {
                this.background = value;
                NotifyPropertyChanged("Background_Change");
            }
        }

        public void Start()
        {
            Client client = Client.Instance;
            if (ListOfCommands != "" && client.isConnected()) { 
                Background_Change = Brushes.Pink;
                String[] commands = listOfCommands.Split('\n');
                client.setListOfCommands(commands);
                client.handleCommand();
                Background_Change = Brushes.White;
            }
        }
    }
}
