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

        /*
         * Constructs a new JoystickViewModel
         */
        public JoystickViewModel()
        {
            model = new JoystickModel();
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        /*
         * VM_Throttle_Change property, returns the value rounded, and sets the value
         */
        public Double VM_Throttle_Change
        {
            get
            {
                return System.Math.Round(model.Throttle_Change, 2);

            }
            set
            {
                model.Throttle_Change = value;
                NotifyPropertyChanged("VM_Throttle_Change");
                handleThrottle();
            }
        }


         /*
         * VM_Aileron_Change property, returns the value rounded, and sets the value
         */
        public Double VM_Aileron_Change
        {
            get
            {
                return System.Math.Round(model.Aileron_Change, 2);
            }
            set
            {
                model.Aileron_Change = value;
                NotifyPropertyChanged("VM_Aileron_Change");
                handleAileron();
            }
        }

        /*
        * VM_Elevator_Change property, returns the value rounded, and sets the value
        */
        public Double VM_Elevator_Change
        {
            get
            {
                return System.Math.Round(model.Elevator_Change, 2);
            }
            set
            {
                model.Elevator_Change = value;
                NotifyPropertyChanged("VM_Elevator_Change");
                handleElevator();
            }
        }

        /*
        * VM_Rudder_Change property, returns the value rounded, and sets the value
        */
        public Double VM_Rudder_Change
        {
            get
            {
                return System.Math.Round(model.Rudder_Change, 2);
            }
            set
            {
                model.Rudder_Change = value;
                NotifyPropertyChanged("VM_Rudder_Change");
                handleRudder();
                
            }
        }

        /*
         * The function creates a new thread which gets the moveThrottle() function as a param
         * and then starts, (the operation is happening in the model, as it sends to the client the updated value)
         */
        public void handleThrottle()
        {
            Thread handle = new Thread(model.moveThrottle);
            handle.IsBackground = true;
            handle.Start();
        }

        /*
        * The function creates a new thread which gets the moveRudder() function as a param
        * and then starts, (the operation is happening in the model, as it sends to the client the updated value)
        */
        public void handleRudder()
        {
            Thread handle = new Thread(model.moveRudder);
            handle.IsBackground = true;
            handle.Start();
        }

        /*
        * The function creates a new thread which gets the moveAileron() function as a param
        * and then starts, (the operation is happening in the model, as it sends to the client the updated value)
        */
        public void handleAileron()
        {
            Thread handle = new Thread(model.moveAileron);
            handle.IsBackground = true;
            handle.Start();
        }

        /*
        * The function creates a new thread which gets the moveElevator() function as a param
        * and then starts, (the operation is happening in the model, as it sends to the client the updated value)
        */
        public void handleElevator()
        {
            Thread handle = new Thread(model.moveElevator);
            handle.IsBackground = true;
            handle.Start();
        }
    }



    

    
}
