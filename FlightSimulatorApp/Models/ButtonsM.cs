namespace FlightSimulatorApp.Models
{
    class ButtonsM
    {
        public void Connect()
        {
            if(!Client.Instance.ClientConnected)
            Client.Instance.Connect(SettingsM.Instance.SimulatorIP, SettingsM.Instance.SimulatorPort);
        }
        public void Disconnect()
        {
            if (Client.Instance.ClientConnected)
                Client.Instance.CloseClient();
        }
    }
}
