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

        public SettingsWindowModel()
        {
            portAndIp = ApplicationSettingsModel.Instance;
            flightServerIp = portAndIp.FlightServerIP;
            flightInfoPort = portAndIp.FlightInfoPort.ToString();
            flightCommandPort = portAndIp.FlightCommandPort.ToString();
        }

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

        public bool CloseTheWindow
        {
            set
            {
                NotifyPropertyChanged("CloseTheWindow");
            }
        }

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
