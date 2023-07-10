namespace FlightSimulatorApp.Models
{
    class Parser
    {
        public static string SendPrepare(string mode, string variable, double value) //send in right format
        {
            if(mode=="set")
            return "set " + variable + " " + value + "\r\n";
            else
            return "get " + variable+"\r\n";
        }
    }
}
