using System;

namespace FlightSimulator.Model
{
    class JoystickModel : IModelNotify
    {
        private double throttle;
        private double aileron;
        private double elevator;
        private double rudder;

        private String[] command;

        /*
         * Constructs a new JoystickModel
         */
        public JoystickModel()
        {
            rudder = 0.0;
            throttle = 0.0;
            aileron = 0.0;
            elevator = 0.0;
            command = new string[1];
        }

        /*
         * Rudder_Change property, returns the value and sets the value
         */
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

        /*
         * Throttle_Change property, returns the value and sets the value
         */
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

        /*
         * Aileron_Change property, returns the value and sets the value
         */
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

        /*
         * Elevator_Change property, returns the value and sets the value
         */
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

        /*
         * The function creates a new client instance, checks if connected, if so, sends via handleCommand() function 
         * the throttle value as a string
         */
        public void moveThrottle()
        {
            Client client = Client.Instance;
            if (client.IsConnected)
            {
                command[0] = "set /controls/engines/current-engine/throttle " + this.throttle.ToString();
                client.setListOfCommands(command);
                client.handleCommand();
            }
        }

        /*
         * The function creates a new client instance, checks if connected, if so, sends via handleCommand() function 
         * the rudder value as a string
         */
        public void moveRudder()
        {
            Client client = Client.Instance;
            if (client.IsConnected)
            {
                command[0] = "set /controls/flight/rudder " + this.rudder.ToString();
                client.setListOfCommands(command);
                client.handleCommand();
            }
        }

        /*
         * The function creates a new client instance, checks if connected, if so, sends via handleCommand() function 
         * the elevator value as a string
         */
        public void moveElevator()
        {
            Client client = Client.Instance;
            if (client.IsConnected)
            {
                command[0] = "set /controls/flight/elevator " + this.elevator.ToString();
                Console.WriteLine("Elevator " + this.elevator);
                client.setListOfCommands(command);
                client.handleCommand();
            }
        }

        /*
         * The function creates a new client instance, checks if connected, if so, sends via handleCommand() function 
         * the aileron value as a string
         */
        public void moveAileron()
        {
            Client client = Client.Instance;
            if (client.IsConnected && client.GetCurrentThread == null)
            {
                command[0] = "set /controls/flight/aileron " + this.aileron.ToString();
                client.setListOfCommands(command);
                client.handleCommand();
            }
        }
    }
}
