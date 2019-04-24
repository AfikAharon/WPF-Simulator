using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        private ICommand _settingCommand;
        private ICommand _connectCommand;
        private FlightBoardModel model;
        
        /*
         * Constructs a new FlightBoardViewModel
         */
        public FlightBoardViewModel()
        {
            model = new FlightBoardModel();
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        /*
         * VM_Lon property, returns the value and sets the value
         */
        public double VM_Lon
        {
            get
            {
                return model.Lon;
            }
            set
            {
                model.Lon = value;
                NotifyPropertyChanged("VM_Lon");
            }
        }

        /*
         * VM_Lat property, returns the value and sets the value
         */
        public double VM_Lat
        {
            get
            {
                return model.Lat;
            }
            set
            {
                model.Lat = value;
                NotifyPropertyChanged("VM_Lat");
            }
        }

        /*
         * settingCommandButton property, returns the value
         */
        public ICommand settingCommandButton
        {
            get
            {
                return _settingCommand ?? (_settingCommand = new CommandHandler(() => settingButton()));
            }
        }

        /*
         * connectCommandButtom property, returns the value
         */
        public ICommand connectCommandButton
        {
            get
            {
                return _connectCommand ?? (_connectCommand = new CommandHandler(() => connectButton()));
            }
        }

        /*
         * Activates the showSetting in the model
         */
        public void settingButton()
        {
            model.showSetting();
        }

        /*
         * Activates the connect in the model
         */
        public void connectButton()
        {
            model.connect();
        }
        
    }
}
