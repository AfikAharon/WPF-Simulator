using FlightSimulator.Model;
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
    class JoystickViewModel : BaseNotify
    {
   
        private JoystickModel model;

        public JoystickViewModel()
        {
            model = new JoystickModel();
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        public Double VM_Throttle_Change
        {
            get
            {
                return model.Throttle_Change;
            }
            set
            {
                model.Throttle_Change = value;
                NotifyPropertyChanged("VM_Throttle_Change");
                handleThrottle();
            }
        }



        public Double VM_Aileron_Change
        {
            get
            {
                return model.Aileron_Change;
            }
            set
            {
                model.Aileron_Change = value;
                NotifyPropertyChanged("VM_Aileron_Change");
                handleAileron();
            }
        }

        public Double VM_Elevator_Change
        {
            get
            {
                return model.Elevator_Change;
            }
            set
            {
                model.Elevator_Change = value;
                NotifyPropertyChanged("VM_Elevator_Change");
                handleElevator();
            }
        }

        public Double VM_Rudder_Change
        {
            get
            {
                return model.Rudder_Change;
            }
            set
            {
                model.Rudder_Change = value;
                NotifyPropertyChanged("VM_Rudder_Change");
                handleRudder();
                
            }
        }

        public void handleThrottle()
        {
            Thread handle = new Thread(model.moveThrottle);
            handle.Start();
        }

        public void handleRudder()
        {
            Thread handle = new Thread(model.moveRudder);
            handle.Start();
        }
        public void handleAileron()
        {
            Thread handle = new Thread(model.moveAileron);
            handle.Start();
        }
        public void handleElevator()
        {
            Thread handle = new Thread(model.moveElevator);
            handle.Start();
        }
    }



    

    
}
