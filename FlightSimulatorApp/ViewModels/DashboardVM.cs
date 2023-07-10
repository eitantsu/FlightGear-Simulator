using FlightSimulatorApp.Models;
using System;
using System.Threading;

namespace FlightSimulatorApp.ViewModels
{
    class DashboardVM : Notifier
    {
        private readonly DashboardM model;
        readonly Mutex mutex=new Mutex();
        private double speedkt0;
        public double SpeedktVM
        {
            get 
            { 
                mutex.WaitOne();
                double temp=speedkt0;
                mutex.ReleaseMutex();
                return temp; 
            }
            set
            {
                mutex.WaitOne();
                if (speedkt0 != model.Speedkt) { 
                speedkt0 = model.Normalize(model.Speedkt);
                NotifyPropertyChanged("SpeedktVM");
                }
                mutex.ReleaseMutex();
            }
        }
        private double gspeedkt0;
        public double GSpeedktVM
        {
            get 
            { 
                mutex.WaitOne();
                double temp=gspeedkt0;
                mutex.ReleaseMutex();
                return temp; 
            }
            set
            {
                mutex.WaitOne();
                if(gspeedkt0!=model.Gspeedkt) { 
                gspeedkt0 = model.Normalize(model.Gspeedkt);
                NotifyPropertyChanged("GSpeedktVM");
                }
                mutex.ReleaseMutex();
            }
        }
        private double vspeed0;
        public double VSpeedVM
        {
            get 
            { 
                mutex.WaitOne();
                double temp=vspeed0;
                mutex.ReleaseMutex();
                return temp; 
            }
            set
            {
                mutex.WaitOne();
                if(vspeed0!=model.Vspeed) { 
                vspeed0 = model.Normalize(model.Vspeed);
                NotifyPropertyChanged("VSpeedVM");
                }
                mutex.ReleaseMutex();
            }
        }
        private double pitch0;
        public double PitchVM
        {
            get 
            { 
                mutex.WaitOne();
                double temp=pitch0;
                mutex.ReleaseMutex();
                return temp; 
            }
            set
            {
                mutex.WaitOne();
                if(pitch0!=model.Pitch) { 
                pitch0 = model.Normalize(model.Pitch);
                NotifyPropertyChanged("PitchVM");
                }
                mutex.ReleaseMutex();
            }
        }
        private double roll0;
        public double RollVM
        {
            get 
            { 
                mutex.WaitOne();
                double temp=roll0;
                mutex.ReleaseMutex();
                return temp; 
            }
            set
            {
                mutex.WaitOne();
                if(roll0!=model.Roll) { 
                roll0 = model.Normalize(model.Roll);
                NotifyPropertyChanged("RollVM");
                }
                mutex.ReleaseMutex();
            }
        }
        private double gpsalt0;
        public double GpsAltVM
        {
            get 
            { 
                mutex.WaitOne();
                double temp=gpsalt0;
                mutex.ReleaseMutex();
                return temp; 
            }
            set
            {
                mutex.WaitOne();
                if(gpsalt0!=model.Gpsalt) { 
                gpsalt0 = model.Normalize(model.Gpsalt);
                NotifyPropertyChanged("GpsAltVM");
                }
                mutex.ReleaseMutex();
            }
        }
        private double meteralt0;
        public double MeterAltVM
        {
            get 
            { 
                mutex.WaitOne();
                double temp=meteralt0;
                mutex.ReleaseMutex();
                return temp; 
            }
            set
            {
                mutex.WaitOne();
                if(meteralt0!=model.Meteralt) { 
                meteralt0 = model.Normalize(model.Meteralt);
                NotifyPropertyChanged("MeterAltVM");
                }
                mutex.ReleaseMutex();
            }
        }
        private double heading0;
        public double HeadingVM
        {
            get 
            { 
                mutex.WaitOne();
                double temp=heading0;
                mutex.ReleaseMutex();
                return temp; 
            }
            set
            {
                mutex.WaitOne();
                if(heading0!=model.Heading) { 
                heading0 = model.Normalize(model.Heading);
                NotifyPropertyChanged("HeadingVM");
                }
                mutex.ReleaseMutex();
            }
        }
        public DashboardVM() 
        { 
            this.model = new DashboardM(); 
        }
    }
}
