using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model.Interface;


namespace FlightSimulator.ViewModels
{
    public class SettingsWindowModel : IModelNotify
    {
        private String flightServerIp;
        private String flightInfoPort;
        private String flightCommandPort;
        ISettingsModel portAndIp;

        /*
         * Constructs a new SettingsWindowModel
         */
        public SettingsWindowModel()
        {
            portAndIp = ApplicationSettingsModel.Instance;
            flightServerIp = portAndIp.FlightServerIP;
            flightInfoPort = portAndIp.FlightInfoPort.ToString();
            flightCommandPort = portAndIp.FlightCommandPort.ToString();
        }

        /*
         * FlightServerIp property, returns the value and sets the value
         */
        public String FlightServerIp
        {
            get
            {
                return flightServerIp;
            }

            set
            {
                this.flightServerIp = value;
                NotifyPropertyChanged("FlightServerIp");
            }
        }

        /*
         * FlightInfoPort property, returns the value and sets the value
         */
        public String FlightInfoPort
        {
            get
            {
                return flightInfoPort;
            }

            set
            {
                this.flightInfoPort = value;
                NotifyPropertyChanged("FlightInfoPort");
            }
        }

        /*
         * FlightCommandPort property, returns the value and sets the value
         */
        public String FlightCommandPort
        {
            get
            {
                return flightCommandPort;
            }

            set
            {
                this.flightCommandPort = value;
                NotifyPropertyChanged("FlightCommandPort");
            }
        }

        /*
         * CloseTheWindow property,  sets the value
         */
        public bool CloseTheWindow
        {
            set
            {
                NotifyPropertyChanged("CloseTheWindow");
            }
        }

        /*
         * The function sets the ip and port values , by parsing them from the ApplicationSettingsModel
         */
        public void setValues()
        {
            if (flightCommandPort != portAndIp.FlightCommandPort.ToString())
            {
                portAndIp.FlightCommandPort = Int32.Parse(flightCommandPort);
            }
            if (flightServerIp != portAndIp.FlightServerIP)
            {
                portAndIp.FlightServerIP = flightServerIp;
            }
            if (flightInfoPort != portAndIp.FlightInfoPort.ToString())
            {
                portAndIp.FlightInfoPort = Int32.Parse(flightInfoPort);
            }
            // close thw window by notify to the VM
            CloseTheWindow = true;
        }

        /*
         * The function resets the ip, port values
         */
        public void restoreMembersValues()
        {
            FlightServerIp = portAndIp.FlightServerIP;
            FlightInfoPort = portAndIp.FlightInfoPort.ToString();
            FlightCommandPort = portAndIp.FlightCommandPort.ToString();
            // close thw window by notify to the VM
           CloseTheWindow = true;
        }
    }
}
