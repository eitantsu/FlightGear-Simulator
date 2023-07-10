using System.Threading;
using System.Collections.Generic;

namespace FlightSimulatorApp.Models
{
    class ValuesHolder //holds all our saved current values
    {
        readonly Dictionary<string, double> valuesTable;
        readonly Mutex mutex;
        public double this[string name]
        {
            get { return valuesTable[name]; }
            set
            {
                mutex.WaitOne();
                valuesTable[name] = value;
                mutex.ReleaseMutex();
            }
        } 
        public ValuesHolder()
        {
            this.mutex = new Mutex();
            valuesTable = new Dictionary<string, double>();
            valuesTable.Add("/instrumentation/airspeed-indicator/indicated-speed-kt",0);
            valuesTable.Add("/instrumentation/gps/indicated-ground-speed-kt", 0);
            valuesTable.Add("/instrumentation/gps/indicated-vertical-speed", 0);
            valuesTable.Add("/instrumentation/altimeter/indicated-altitude-ft",0);
            valuesTable.Add("/instrumentation/gps/indicated-altitude-ft", 0);
            valuesTable.Add("/instrumentation/attitude-indicator/internal-pitch-deg",0);
            valuesTable.Add("/instrumentation/attitude-indicator/internal-roll-deg",0);         
            valuesTable.Add("/instrumentation/heading-indicator/indicated-heading-deg",0);
            valuesTable.Add("/position/latitude-deg",0); 
            valuesTable.Add("/position/longitude-deg",0);
            valuesTable.Add("/controls/flight/aileron",0);
            valuesTable.Add("/controls/flight/elevator",0);
            valuesTable.Add("/controls/flight/rudder",0);
            valuesTable.Add("/controls/engines/current-engine/throttle",0);
        }
    }
}

