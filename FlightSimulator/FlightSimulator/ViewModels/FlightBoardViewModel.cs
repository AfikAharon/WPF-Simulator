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
        
        public FlightBoardViewModel()
        {
            model = new FlightBoardModel();
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }
        
        public double Lon
        {
            get { return 0; }
        }

        public double Lat
        {
            get { return 0; }
        }

        
        public ICommand settingCommandButton
        {
            get
            {
                return _settingCommand ?? (_settingCommand = new CommandHandler(() => settingButton()));
            }
        }
        


        
        public ICommand connectCommandButton
        {
            get
            {
                return _connectCommand ?? (_connectCommand = new CommandHandler(() => connectButton()));
            }
        }

        public void settingButton()
        {
            model.showSetting();
        }

        public void connectButton()
        {
            model.connect();
        }
        
    }
}
