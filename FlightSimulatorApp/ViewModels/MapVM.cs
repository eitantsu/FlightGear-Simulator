using FlightSimulatorApp.Models;
using System.Threading;
using System.Windows;

namespace FlightSimulatorApp.ViewModels
{
    public class MapVM : Notifier
    {
        private readonly MapM model;
        readonly Mutex mutex=new Mutex();
        public MapVM()
        {
            model = new MapM();
        }
        private double longitude0;
        public double LongitudeVM
        {
            get
            { 
                mutex.WaitOne(); 
                double temp=longitude0; 
                mutex.ReleaseMutex(); 
                return temp; 
            }
            set
            {
                mutex.WaitOne();
                if(longitude0!=model.Longitude) { 
                longitude0 = model.Normalize(model.Longitude);
                //NotifyPropertyChanged("LongitudeVM");
                }
                mutex.ReleaseMutex();
            }
        }
        private double latitude0;
        public double LatitudeVM
        {
            get
            { 
                mutex.WaitOne();
                double temp = latitude0;
                mutex.ReleaseMutex();
                return temp;
            }
            set
            {
                mutex.WaitOne();
                if(latitude0!=model.Latitude) { 
                latitude0 = model.Normalize(model.Latitude);
               // NotifyPropertyChanged("LatitudeVM");
                }
                mutex.ReleaseMutex();
            }
        }
        private Point point0;
        public Point LonLatVM //unite both values to make notify once together
        {
            get
            {
                mutex.WaitOne();
                Point temp = point0;
                mutex.ReleaseMutex();
                return temp;
            }
            set
            {
                mutex.WaitOne();
                point0=value; //empty use
                latitude0 = model.Normalize(model.Latitude);
                longitude0 = model.Normalize(model.Longitude);
                NotifyPropertyChanged("LonLatVM");
                mutex.ReleaseMutex();
            }
        }
    }
}
