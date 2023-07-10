using FlightSimulatorApp.Models;
using FlightSimulatorApp.Views;
using System.Windows;
using System.Windows.Input;

namespace FlightSimulatorApp.ViewModels
{
    class ButtonsVM
    {
       private readonly ButtonsM model;
        public ButtonsVM()
        {
            model = new ButtonsM();
        }
        private ICommand openSettingsCM0;
        public ICommand OpenSettingsCM
        {
            get
            {
                return openSettingsCM0 ?? (openSettingsCM0 = new CommandHandler(() => OpenSettings()));
            }
        }
        private void OpenSettings()
        {
            foreach (var window in Application.Current.Windows) //already opened
            {
                if (window is SettingsV)
                {
                  return;
                }
            }
            SettingsV settings = new SettingsV();
            settings.Show();
        }
        private ICommand connectCM0;
        public ICommand ConnectCM
        {
            get
            {
                return connectCM0 ?? (connectCM0 = new CommandHandler(() => Connect()));
            }
        }
        private void Connect() 
        { 
            model.Connect(); 
        }
        private ICommand disconnectCM0;
        public ICommand DisconnectCM
        {
            get
            {
                return disconnectCM0 ?? (disconnectCM0 = new CommandHandler(() => Disconnect()));
            }
        }
        private void Disconnect() 
        { 
            model.Disconnect(); 
        }
    }
}
