using System;

namespace FlightSimulatorApp.Models
{
    class MapM
    {
        public double Normalize(double value)
        {
            return (double)Convert.ToInt32(value * 100) / (double)100;
        }
        public double Latitude
        {
            get
            {
                return Client.Instance.ValuesHolder["/position/latitude-deg"];
            }
        }
        public double Longitude
        {
            get
            {
                return Client.Instance.ValuesHolder["/position/longitude-deg"];
            }
        }
    }
}
