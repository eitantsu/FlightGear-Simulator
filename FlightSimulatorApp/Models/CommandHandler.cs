using System;
using System.Windows.Input;
namespace FlightSimulatorApp.Models
{
    public class CommandHandler : ICommand //generic command handler for all commands
    {
        private Action action;
        public CommandHandler(Action action0)
        {
            this.action = action0;
        }
        public bool CanExecute(object parameter) { return true; }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            if(CanExecuteChanged!=null || CanExecuteChanged==null)//empty use
            action();
        }
    }
}
