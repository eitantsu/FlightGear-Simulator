using FlightSimulatorApp.Models;

namespace FlightSimulatorApp.ViewModels
{
    class ValuesVM : Notifier
    {
        private readonly ValuesM model;
        private double aileron0;
        public double AileronVM
        {
            get { return (aileron0); }
            set
            {
                value = model.Normalize(value);
                aileron0 = value;
                NotifyPropertyChanged("AileronVM");
                model.Elevator = value;
            }
        }
        private double elevator0;
        public double ElevatorVM
        {
            get { return (elevator0); }
            set
            {
                value = model.Normalize(value);
                elevator0 = value;
                NotifyPropertyChanged("ElevatorVM");
                model.Alieron = value;
            }
        }
        private double aileronStep0;
        public double AileronRateVM
        {
            get { return (aileronStep0); }
            set
            {
                value = model.Normalize(value);
                aileronStep0 = value;
                NotifyPropertyChanged("AileronRateVM");
                model.Elevator += value;
            }
        }
        private double elevatorStep0;
        public double ElevatorRateVM
        {
            get { return (elevatorStep0); }
            set
            {
                value = model.Normalize(value);
                elevatorStep0 = value;
                NotifyPropertyChanged("ElevatorRateVM");
                model.Alieron += value;
            }
        }
        private double throttle0;
        public double ThrottleVM
        {
            get { return (throttle0); }
            set
            {
                value = model.Normalize(value);
                throttle0 = value;
                NotifyPropertyChanged("ThrottleVM");
                model.Throttle = value;
            }
        }
        private double rudder0;
        public double RudderVM
        {
            get { return (rudder0); }
            set
            {
                value = model.Normalize(value);
                rudder0 = value;
                NotifyPropertyChanged("RudderVM");
                model.Rudder = value;
            }
        }
        public ValuesVM() 
        { 
            this.model = new ValuesM(); 
        }
    }
}
