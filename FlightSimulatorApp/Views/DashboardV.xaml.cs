using FlightSimulatorApp.Models;
using FlightSimulatorApp.ViewModels;
using System;
using System.Threading;
using System.Windows.Controls;

namespace FlightSimulatorApp.Views
{
    public partial class DashboardV : UserControl
    {
       private readonly DashboardVM viewModel;
        public DashboardV() { 
            InitializeComponent();
            viewModel = new DashboardVM();
            this.DataContext = viewModel; 
            Thread t=new Thread(Run);
            t.IsBackground=true;
            t.Start();
        }
        private void Run() {
           while(true) //continously set to notify change
            {
                if (!Client.EndThreads) { 
                viewModel.GSpeedktVM = 0;
                viewModel.SpeedktVM = 0;
                viewModel.VSpeedVM = 0;
                viewModel.PitchVM = 0;
                viewModel.RollVM = 0;
                viewModel.GpsAltVM = 0;
                viewModel.MeterAltVM = 0;
                viewModel.HeadingVM = 0;
                Thread.Sleep(250);
                }
            }
        }
}
}
