using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using FlightSimulatorApp.Models;
using FlightSimulatorApp.ViewModels;
using Microsoft.Maps.MapControl.WPF;

namespace FlightSimulatorApp.Views
{ 
    public partial class MapV : UserControl
    {
        private readonly MapVM viewModel;
        public static bool FirstValue=false; //dont show default pin location until updated
        public MapV()
        {
            InitializeComponent();
            viewModel = new MapVM();
            this.DataContext = viewModel;
            Thread t = new Thread(Run);
           // t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.IsBackground = true;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs event0)
        {
            viewModel.PropertyChanged += VM_PropertyChanged;
        }
        private void VM_PropertyChanged(object sender, PropertyChangedEventArgs event0)
        {
            if (event0.PropertyName.Equals("LonLatVM") && FirstValue)
            {
                Point p = new Point(viewModel.LongitudeVM, viewModel.LatitudeVM);
                Task.Run(() => UpdateGraph(p)); //dont collide with ui main thread
            }
        }
        void UpdateGraph(Point p)
        {
            if (Client.Instance.ClientConnected)
            {
                Application.Current.Dispatcher.Invoke((Action)delegate {
                    Location loc = new Location
                    {
                        Latitude = p.X,
                        Longitude = p.Y
                    };
                    Pushpin pushpin = new Pushpin();
                    MapLayer.SetPosition(pushpin, loc);
                    bmap.Children.Clear();
                    bmap.Children.Add(pushpin);
                });
            }
        }
        public Point LonLat
        {
            get
            {
                return (Point)GetValue(LonLatProperty);
            }
            set
            {
                SetValue(LonLatProperty, value);
            }
        }
        public static readonly DependencyProperty LonLatProperty = DependencyProperty.Register("LonLat", typeof(Point), typeof(MapV));
        private void Run()
        {
            while (true) //continously set to notify change
            {
                if(!Client.EndThreads) { viewModel.LonLatVM=new Point(0,0); Thread.Sleep(250); }
                }


            }
    }
}