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
    public class SettingsWindowViewModel : BaseNotify
    {

        private ICommand _okCommand;
        private ICommand _cancelCommand;
        private SettingsWindowModel model;

        /*
         * Constructs a new SettingsWindowViewModel
         */
        public SettingsWindowViewModel()
        {
            model = new SettingsWindowModel();
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
                return _okCommand ?? (_okCommand = new CommandHandler(() => okCommand()));
            }
        }

        /*
         * cancelCommandButton property, returns the value
         */
        public ICommand cancelCommandButton
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new CommandHandler(() => cancelCommand()));
            }
        }

        /*
         * VM_FlightServerIp property, returns the value, and sets the value
         */
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

        /*
         * VM_FlightInfoPort property, returns the value, and sets the value
         */
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

        /*
         * VM_CloseTheWindow property, sets the value
         */
        public bool VM_CloseTheWindow
        {
            set
            {
                NotifyPropertyChanged("VM_CloseTheWindow");
            }
        }

        /*
         * VM_FlightCommandPort property, returns the value, and sets the value
         */
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

        /*
         * Activates the setValues function in the model
         */
        public void okCommand()
        {
            model.setValues();
        }

        /*
         * Activates the cancelCommand function in the model
         */
        public void cancelCommand()
        {
            model.restoreMembersValues();
        }
    }
}