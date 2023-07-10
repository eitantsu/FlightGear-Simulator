using FlightSimulatorApp.ViewModels;
using System.Windows.Controls;

namespace FlightSimulatorApp.Views
{
    /// <summary>
    /// Interaction logic for JoystickAdded.xaml
    /// </summary>
    public partial class JoystickAdded : UserControl
    {
        public JoystickAdded()
        {
            InitializeComponent();
            this.DataContext = new ValuesVM();
        }

    }
}
