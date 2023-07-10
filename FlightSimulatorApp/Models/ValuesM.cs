using System;

namespace FlightSimulatorApp.Models
{
    class ValuesM
    {
        public double Throttle
        {
            set
            {
                if (Client.Instance.ClientConnected) 
                    Client.Instance.ValuesHolder["/controls/engines/current-engine/throttle"] = value;
            }
        }
        public double Rudder
        {
            set
            {
                if (Client.Instance.ClientConnected)
                    Client.Instance.ValuesHolder["/controls/flight/rudder"] = value;
            }
        }
        public double Alieron
        {
            get
            {
                if (Client.Instance.ClientConnected)
                    return Client.Instance.ValuesHolder["/controls/flight/aileron"];
                return 0;
            }
            set
            {
                if (Client.Instance.ClientConnected) 
                    Client.Instance.ValuesHolder["/controls/flight/aileron"] = value;
            }
        }
        public double Elevator
        {
            get
            {
                if (Client.Instance.ClientConnected)
                    return Client.Instance.ValuesHolder["/controls/flight/elevator"];
                return 0;
            }
            set
            {
                if (Client.Instance.ClientConnected)
                    Client.Instance.ValuesHolder["/controls/flight/elevator"] = value;
            }
        }
        public double Normalize(double value)
        {
            return (double)Convert.ToInt32(value * 100) / (double)100;
        }
    }
}

