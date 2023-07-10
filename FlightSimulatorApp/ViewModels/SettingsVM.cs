using System.Windows;
using System.Windows.Input;
using FlightSimulatorApp.Models;
using FlightSimulatorApp.Views;

namespace FlightSimulatorApp.ViewModels
{
    public class SettingsVM : Notifier
    {
        private readonly SettingsM model;
        public SettingsVM() 
        { 
            this.model=new SettingsM(); 
        }

        private string SimulatorIP0 = null;
        public string SimulatorIP
        {
            get
            {
                if (SimulatorIP0 == null) { SimulatorIP0 = model.SimulatorIP; }
                return SimulatorIP0;
            }
            set { this.SimulatorIP0 = value; }
        }


        private int? SimulatorPort0 = null;
        public int SimulatorPort
        {
            get
            {
                if (SimulatorPort0 == null) 
                { 
                    SimulatorPort0 = model.SimulatorPort; 
                }
                return (int)SimulatorPort0;
            }
            set
            {
                this.SimulatorPort0 = value;
            }
        }
        public void SaveSettings() { model.SaveSettings(); }
        public void ReloadSettings() { model.ReloadSettings(); }


        private ICommand clickCM0;
        public ICommand ClickCM
        {
            get
            {
                return clickCM0 ?? (clickCM0 = new CommandHandler(() => Click()));
            }
        }
        private void Click()
        {
            model.SimulatorIP = this.SimulatorIP;
            model.SimulatorPort = this.SimulatorPort;
            model.SaveSettings();
            NotifyPropertyChanged("SimulatorIP");
            NotifyPropertyChanged("SimulatorPort");
            foreach (var window in Application.Current.Windows)
            {
                if (window is SettingsV)
                {
                    (window as Window).Close();
                }
            }
        }

        private ICommand cancelCM0;
        public ICommand CancelCM
        {
            get
            {
                return cancelCM0 ?? (cancelCM0 = new CommandHandler(() => Cancel()));
            }
        }
        private void Cancel()
        {
            model.ReloadSettings();
            foreach (var window in Application.Current.Windows)
            {
                if (window is SettingsV)
                {
                    (window as Window).Close();
                }
            }
        }
    }
}
