using FlightSimulatorApp.ViewModels;
using System.Windows.Controls;

namespace FlightSimulatorApp.Views
{
    /// <summary>
    /// Interaction logic for ButtonsV.xaml
    /// </summary>
    public partial class ButtonsV : UserControl
    {
        public ButtonsV()
        {
            InitializeComponent();
            this.DataContext = new ButtonsVM();
        }
    }
}
