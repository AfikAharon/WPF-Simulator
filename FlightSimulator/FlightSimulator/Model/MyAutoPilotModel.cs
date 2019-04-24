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

        /*
         * Constructs a new MyAutoPilotModel
         */
        public MyAutoPilotModel()
        {
            listOfCommands = "";
            Background_Change = Background_Change = Brushes.White;
        }

        /*
         * ListOfCommands property, returns the value and sets the value
         */
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

        /*
         * Background_Change property, returns the value and sets the value
         */
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

        /*
         * The handleClient() functions creates an instance of the client, see if the text has changed,
         * if so, colors the background in pink, and sends the commands to the client
         */
        public void handleClient()
        {
            Client client = Client.Instance;
            if (ListOfCommands != "") { 
                //Background_Change = Brushes.Pink;
                String[] commands = listOfCommands.Split('\n');
                client.setListOfCommands(commands);
                client.handleCommand();
                Background_Change = Brushes.White;
            }
            // indication that the thread finish the operation
            client.GetCurrentThread = null;
        }
    }
}
