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

        public MyAutoPilotViewModel()
        {
            model = new MyAutoPilotModel();
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }
    

       public ICommand okCommandButton
        {
            get
            {   
                return _okCommand ?? (_okCommand = new CommandHandler(() => sendCommands()));
            }
        }

        public ICommand clearCommandButton
        {
            get
            {
                return _clearCommand ?? (_clearCommand = new CommandHandler(() => clearCommands()));
            }
        }

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