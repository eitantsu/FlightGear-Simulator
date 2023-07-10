using FlightSimulatorApp.Models;
using System.Windows;



namespace FlightSimulatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Focus();
        }
        public void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Client.Instance.ClientConnected)
            {
                e.Cancel = true;
                Client.Instance.CloseClient();
            }
            e.Cancel = false;
        }
    }
}