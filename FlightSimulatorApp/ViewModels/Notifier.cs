using System.ComponentModel;

namespace FlightSimulatorApp.ViewModels
{
    public abstract class Notifier : INotifyPropertyChanged //generic class which all derived classes get it's methods
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string prop)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
