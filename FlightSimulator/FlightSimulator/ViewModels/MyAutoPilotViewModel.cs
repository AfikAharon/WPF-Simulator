using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using FlightSimulator.Model;
using FlightSimulator.Views;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Threading;
using System.Windows.Media;


namespace FlightSimulator.ViewModels
{
    class MyAutoPilotViewModel: BaseNotify
    {
        
        private ICommand _okCommand;
        private ICommand _clearCommand;
        private MyAutoPilotModel model;

        /*
         * Constructs a new MyAutoPilotViewModel
         */
        public MyAutoPilotViewModel()
        {
            model = new MyAutoPilotModel();
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }
    
        /*
         * okCommandButton property, returns the value
         */
       public ICommand okCommandButton
        {
            get
            {   
                return _okCommand ?? (_okCommand = new CommandHandler(() => sendCommands()));
            }
        }

        /*
        * clearCommandButton property, returns the value
        */
        public ICommand clearCommandButton
        {
            get
            {
                return _clearCommand ?? (_clearCommand = new CommandHandler(() => clearCommands()));
            }
        }

        /*
         * VM_Background_Change property, returns the value and sets the value
        */
        public Brush VM_Background_Change
        {
            get
            {
                return model.Background_Change;
            }
            set
            {
                model.Background_Change = value;
                NotifyPropertyChanged("VM_Background_Change");
            }
        }


        /*
         * VM_TextBoxCommands property, returns the value and sets the value
        */
        public String VM_TextBoxCommands
        {
            get
            {
                return model.ListOfCommands;
            }
            set
            {
                model.ListOfCommands = value;
                NotifyPropertyChanged("VM_TextBoxCommands");
            }
        }

        /*
         * The function sends all the commands in the auto pilot window to the client
        */
        public void sendCommands()
        {
            Client client = Client.Instance;
            if (client.IsConnected)
            {
                Thread clientThread = new Thread(model.handleClient);
                clientThread.Start();
                client.GetCurrentThread = clientThread;
            }
        }

        /*
        * The function clears the textbox in the auto pilot
        */
        public void clearCommands()
        {
            VM_TextBoxCommands = "";
        }
    }
}


/*
set controls/flight/rudder -1
set controls/flight/rudder 1
set controls/flight/rudder -1
set controls/flight/rudder 1
*/