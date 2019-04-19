using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    class SettingsWindowViewModel : BaseNotify
    {

        private ICommand _okCommand;
        private ICommand _cancelCommand;
        private SettingsWindowModel model;

        public SettingsWindowViewModel()
        {
            model = new SettingsWindowModel();
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        public ICommand okCommandButton
        {
            get
            {
                return _okCommand ?? (_okCommand = new CommandHandler(() => okCommand()));
            }
        }

        public ICommand cancelCommandButton
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new CommandHandler(() => cancelCommand()));
            }
        }

        public String VM_FlightServerIp
        {
            get
            {
                return model.FlightServerIp;
            }
            set
            {
                model.FlightServerIp = value;
                NotifyPropertyChanged("VM_FlightServerIp");
            }
        }

        public String VM_FlightInfoPort
        {
            get
            {
                return model.FlightInfoPort;
            }
            set
            {
                model.FlightInfoPort = value;
                NotifyPropertyChanged("VM_FlightInfoPort");
            }
        }

        public String VM_FlightCommandPort
        {
            get
            {
                return model.FlightCommandPort;
            }
            set
            {
                model.FlightCommandPort = value;
                NotifyPropertyChanged("VM_FlightCommandPort");
            }
        }

        public void okCommand()
        {
            model.setValues();
        }

        public void cancelCommand()
        {
            model.restoreMembersValues();
        }
    }
}
