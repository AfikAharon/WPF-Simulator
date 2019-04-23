using System;

namespace FlightSimulator.Model
{
    class JoystickModel : IModelNotify
    {
        private double throttle;
        private double aileron;
        private double elevator;
        private double rudder;
        private string aileronVal;
        private String[] command;

        public JoystickModel()
        {
            rudder = 0.0;
            throttle = 0.0;
            aileron = 0.0;
            elevator = 0.0;
            aileronVal = "";
            command = new string[1];
        }

        public String Aileron_Val
        {
            get
            {
                return aileronVal;
            }

            set
            {
                this.aileronVal = value;
                NotifyPropertyChanged("Aileron_Val");

            }
        }
        public Double Rudder_Change
        {
            get
            {
                return rudder;
            }

            set
            {
                this.rudder = value;
                NotifyPropertyChanged("Rudder_Change");
            }
        }

        public Double Throttle_Change
        {
            get
            {
                return throttle;
            }

            set
            {
                this.throttle = value;
                NotifyPropertyChanged("Throttle_Change");
            }
        }

        public Double Aileron_Change
        {
            get
            {
                return aileron;
            }

            set
            {
                this.aileron = value;
                NotifyPropertyChanged("Aileron_Change");
            }
        }

        public Double Elevator_Change
        {
            get
            {
                return elevator;
            }

            set
            {
                this.elevator = value;
                NotifyPropertyChanged("Elevator_Change");
            }
        }



        public void moveThrottle()
        {
            Client client = Client.Instance;
            if (client.isConnected())
            {
                command[0] = "set /controls/engines/current-engine/throttle " + this.throttle.ToString();
                client.setListOfCommands(command);
                client.handleCommand();
            }
        }

        public void moveRudder()
        {
            Client client = Client.Instance;
            if (client.isConnected())
            {
                command[0] = "set /controls/flight/rudder " + this.rudder.ToString();
                client.setListOfCommands(command);
                client.handleCommand();
            }
        }

        public void moveElevator()
        {
            Client client = Client.Instance;
            if (client.isConnected())
            {
                command[0] = "set /controls/flight/elevator " + this.elevator.ToString();
                Console.WriteLine("Elevator " + this.elevator);
                client.setListOfCommands(command);
                client.handleCommand();
            }
        }

        public void moveAileron()
        {
            Client client = Client.Instance;
            if (client.isConnected())
            {
                command[0] = "set /controls/flight/aileron " + this.aileron.ToString();
                client.setListOfCommands(command);
                client.handleCommand();
            }
        }


    }
}
