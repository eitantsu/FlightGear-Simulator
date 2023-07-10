using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using FlightSimulatorApp.Models;

namespace FlightSimulatorApp.Views
{
    public partial class Joystick : UserControl
    {
        public static readonly DependencyProperty AileronProperty = DependencyProperty.Register("Aileron", typeof(double), typeof(Joystick), null);
        public static readonly DependencyProperty ElevatorProperty = DependencyProperty.Register("Elevator", typeof(double), typeof(Joystick), null);
        public static readonly DependencyProperty AileronRateProperty = DependencyProperty.Register("AileronRate", typeof(double), typeof(Joystick), new PropertyMetadata(1.0));
        public static readonly DependencyProperty ElevatorRateProperty = DependencyProperty.Register("ElevatorRate", typeof(double), typeof(Joystick), new PropertyMetadata(1.0));
        public double Aileron
        {
            get 
            { 
                return Convert.ToDouble(GetValue(AileronProperty)); 
            }
            set 
            { 
                SetValue(AileronProperty, value); 
            }
        }
        public double Elevator
        {
            get 
            { 
                return Convert.ToDouble(GetValue(ElevatorProperty)); 
            }
            set 
            { 
                SetValue(ElevatorProperty, value); 
            }
        }
        public double AileronRate
        {
            get 
            { 
                return Convert.ToDouble(GetValue(AileronRateProperty)); 
            }
            set
            {
                if (value < 1) value = 1; 
                else if (value > 90) value = 90;
                SetValue(AileronRateProperty, Math.Round(value));
            }
        } 
        public double ElevatorRate
        {
            get 
            { 
                return Convert.ToDouble(GetValue(ElevatorRateProperty)); 
            }
            set
            {
                if (value < 1) value = 1; 
                else if (value > 50) value = 50;
                SetValue(ElevatorRateProperty, value);
            }
        }
        public delegate void OnScreenJoystickEventHandler(Joystick sender, JoystickValues vals);
        public delegate void EmptyJoystickEventHandler(Joystick sender);
        public event OnScreenJoystickEventHandler Moved;
        public event EmptyJoystickEventHandler Released;
        public event EmptyJoystickEventHandler Captured;
        private Point startPoint;
        private double prevAileron, prevElevator;
        private double canvasWidth, canvasHeight;
        private readonly Storyboard centerKnob;
        public Joystick()
        {
            InitializeComponent();
            Knob.MouseLeftButtonDown += Knob_MouseLeftButtonDown; //add our custom events
            Knob.MouseLeftButtonUp += Knob_MouseLeftButtonUp;
            Knob.MouseMove += Knob_MouseMove;
            centerKnob = Knob.Resources["CenterKnob"] as Storyboard;
        }
        private void Knob_MouseLeftButtonDown(object sender, MouseButtonEventArgs event0)
        {
            startPoint = event0.GetPosition(Base);
            prevAileron = prevElevator = 0;
            canvasWidth = Base.ActualWidth - KnobBase.ActualWidth;
            canvasHeight = Base.ActualHeight - KnobBase.ActualHeight;
            Captured?.Invoke(this);
            Knob.CaptureMouse();
            centerKnob.Stop();
        }
        private void Knob_MouseMove(object sender, MouseEventArgs event0)
        {
            if (!Knob.IsMouseCaptured) return;
            Point newPoint = event0.GetPosition(Base);
            Point difference = new Point(newPoint.X - startPoint.X, newPoint.Y - startPoint.Y);
            double distance = Math.Round(Math.Sqrt(difference.X * difference.X + difference.Y * difference.Y));
            if (distance >= canvasWidth / 2 || distance >= canvasHeight / 2) return;  //outside joystick relevant view
            Aileron = -difference.Y / (canvasHeight / 2);
            Elevator = difference.X / (canvasWidth / 2);
            knobPosition.X = difference.X;
            knobPosition.Y = difference.Y;
            if (Moved == null || (!(Math.Abs(prevAileron - Aileron) > AileronRate) && !(Math.Abs(prevElevator - Elevator) > ElevatorRate))) return;
            Moved?.Invoke(this, new JoystickValues { Aileron = Aileron, Elevator = Elevator });
            prevAileron = Aileron;
            prevElevator = Elevator;
        }
        private void Knob_MouseLeftButtonUp(object sender, MouseButtonEventArgs event0)
        {
            Knob.ReleaseMouseCapture();
            centerKnob.Begin(); //return to center
        }
        private void centerKnob_Completed(object sender, EventArgs event0)
        {
            Aileron = Elevator = prevAileron = prevElevator = 0;
            Released?.Invoke(this);
        }
    }
}