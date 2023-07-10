using FlightSimulatorApp.ViewModels;
using System.Windows;

namespace FlightSimulatorApp.Views
{
    public partial class SettingsV : Window
    {
        public SettingsV() { 
            InitializeComponent(); 
            this.DataContext=new SettingsVM(); 
        }
    }
}
