namespace FlightSimulatorApp.Models
{
    public class SettingsM
    {
        private static SettingsM instance = null;
        public static SettingsM Instance
        {
            get
            {
                if (instance == null) { instance = new SettingsM(); }
                return instance;
            }
        }
        public string SimulatorIP
        {
            get { return Properties.Settings.Default.SimulatorIP; }
            set { Properties.Settings.Default.SimulatorIP = value; }
        }
        public int SimulatorPort
        {
            get { return Properties.Settings.Default.SimulatorPort; }
            set { Properties.Settings.Default.SimulatorPort = value; }
        }
        public void SaveSettings() { Properties.Settings.Default.Save(); }
        public void ReloadSettings() { Properties.Settings.Default.Reload(); }
    }
}
