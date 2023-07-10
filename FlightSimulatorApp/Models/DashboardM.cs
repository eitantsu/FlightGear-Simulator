using System;

namespace FlightSimulatorApp.Models
{
    class DashboardM
    {
        public double Normalize(double value)
        {
            return (double)Convert.ToInt32(value * 100) / (double)100;
        }
        public double Speedkt
        {
            get
            {
                return Client.Instance.ValuesHolder["/instrumentation/airspeed-indicator/indicated-speed-kt"];
            }
        }
        public double Gspeedkt
        {
            get
            {
                return Client.Instance.ValuesHolder["/instrumentation/gps/indicated-ground-speed-kt"];
            }
        }
        public double Vspeed
        {
            get
            {
                return Client.Instance.ValuesHolder["/instrumentation/gps/indicated-vertical-speed"];
            }
        }
        public double Pitch
        {
            get
            {
                return Client.Instance.ValuesHolder["/instrumentation/attitude-indicator/internal-pitch-deg"];
            }
        }
        public double Roll
        {
            get
            {
                return Client.Instance.ValuesHolder["/instrumentation/attitude-indicator/internal-roll-deg"];
            }
        }
        public double Gpsalt
        {
            get
            {
                return Client.Instance.ValuesHolder["/instrumentation/gps/indicated-altitude-ft"];
            }
        }
        public double Meteralt
        {
            get
            {
                return Client.Instance.ValuesHolder["/instrumentation/altimeter/indicated-altitude-ft"];
            }
        }
        public double Heading
        {
            get
            {
               return Client.Instance.ValuesHolder["/instrumentation/heading-indicator/indicated-heading-deg"];
            }
        }
    }
}

