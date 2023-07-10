using System;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Threading;
using FlightSimulatorApp.Views;
using System.Timers;
using System.Diagnostics;

namespace FlightSimulatorApp.Models
{    
    class Client
    {
        public static bool EndThreads = false;
        public static int ThreadsEnded=0;
        private readonly int ThreadsNum=1;
        static Client instance0;
        public static Client Instance
        {
            get
            {
                if (instance0 == null) { instance0 = new Client(); }
                return instance0;
            }
        }

        private readonly ValuesHolder valuesHolder0;
        public ValuesHolder ValuesHolder
        {
            get
            {
                return valuesHolder0;
            }
        }
        TcpClient client;
        readonly Mutex mutex;
        
        public Client() {
            client = new TcpClient();
            client.ReceiveTimeout=10000;
            client.SendTimeout=10000;
            valuesHolder0 = new ValuesHolder();
            mutex=new Mutex();
        }
        ~Client() { CloseClient(); }
        public bool ClientConnected { get { return client.Connected; } }
        public void Connect(string ip, int port)
        {
            try {
                if(ThreadsEnded==1) ThreadsEnded = 0; //if server closed unexpectedly, reset 
                client = new TcpClient();
                client.ReceiveTimeout = 10000;
                client.SendTimeout = 10000;
                client.Connect(IPAddress.Parse(ip), port); 
                Thread t=new Thread(Run);
                t.IsBackground=true;
                t.Start();
                Console.WriteLine("connected");
            }
            catch (Exception e) { Console.WriteLine("could not connect, try again",e.ToString()); }
        }
        public string Send(string mode,string variable, double value,NetworkStream stream,StreamReader reader)
        {
            mutex.WaitOne();
                
               string message=Parser.SendPrepare(mode,variable, value);
                byte[] buffer = Encoding.ASCII.GetBytes(message);
                try {
                stream.Write(buffer, 0, buffer.Length);
                } catch (Exception e) {
                if (e.Message.Contains("time")) Console.WriteLine("server is busy", e.ToString()); //if timeout specific exception
                else Console.WriteLine("could not send",e.ToString()); mutex.ReleaseMutex(); return "";}
                mutex.ReleaseMutex();
                return Read(stream,reader); 
        }
        public void CloseClient()
        {
            if (client.Connected) { 
                EndThreads=true; //mark for threads to end
                while (ThreadsEnded < ThreadsNum) { } //wait for all threads to end
                client.Close(); 
                Console.WriteLine("disconnected");
            }
            EndThreads=false; //reset for next run
            ThreadsEnded=0;
            client=new TcpClient();
        }
        public string Read(NetworkStream stream, StreamReader reader)
        {
            string message = "";
            try { message = reader.ReadLine();
                return message;
            } catch (Exception e) {
                if(e.Message.Contains("time")) Console.WriteLine("server is busy",e.ToString()); //if timeout specific exception
                else Console.WriteLine("could not read", e.ToString());
                return "";
            }
        }
        public void UpdateValuesHolder(NetworkStream stream, StreamReader reader)  //get all values
        {
                    string s;
                    s=Send("get","/position/latitude-deg",0, stream, reader);
                    if (s == "ERR") Console.WriteLine("simulator error"); 
                    else {
                    try { 
                    if (Double.Parse(s) > 90 || Double.Parse(s) < -90) Console.WriteLine("invalid earth coordinates");
                    else ValuesHolder["/position/latitude-deg"] = Double.Parse(s); MapV.FirstValue=true;
                    } catch (Exception e) { if (Client.Instance.ClientConnected) Console.WriteLine("server side error",e.ToString()); }
                    }

                    s =Send("get", "/position/longitude-deg", 0, stream, reader); 
                    if (s == "ERR") Console.WriteLine("simulator error"); 
                    else {
                    try { 
                    if (Double.Parse(s) > 180 || Double.Parse(s) < -180) Console.WriteLine("invalid earth coordinates");
                    else ValuesHolder["/position/longitude-deg"] = Double.Parse(s); MapV.FirstValue = true;
                } catch (Exception e) { if (Client.Instance.ClientConnected) Console.WriteLine("server side error", e.ToString()); }
                    }

                    s =Send("get", "/instrumentation/airspeed-indicator/indicated-speed-kt", 0, stream, reader);
                    if (s == "ERR") Console.WriteLine("simulator error"); 
                    else try { ValuesHolder["/instrumentation/airspeed-indicator/indicated-speed-kt"] = Double.Parse(s);
                    } catch (Exception e) { if (Client.Instance.ClientConnected) Console.WriteLine("server side error", e.ToString()); }

                    s =Send("get", "/instrumentation/gps/indicated-ground-speed-kt", 0, stream, reader);
                    if (s == "ERR") Console.WriteLine("simulator error"); 
                    else try { ValuesHolder["/instrumentation/gps/indicated-ground-speed-kt"] = Double.Parse(s);
                    } catch (Exception e) { if (Client.Instance.ClientConnected) Console.WriteLine("server side error", e.ToString()); }

                    s =Send("get", "/instrumentation/gps/indicated-vertical-speed", 0, stream, reader);
                    if (s == "ERR") Console.WriteLine("simulator error"); 
                    else try { ValuesHolder["/instrumentation/gps/indicated-vertical-speed"] = Double.Parse(s);
                    } catch (Exception e) { if (Client.Instance.ClientConnected) Console.WriteLine("server side error", e.ToString()); }

                    s =Send("get", "/instrumentation/altimeter/indicated-altitude-ft", 0, stream, reader);
                    if (s == "ERR") Console.WriteLine("simulator error"); 
                    else try { ValuesHolder["/instrumentation/altimeter/indicated-altitude-ft"] = Double.Parse(s);
                    } catch (Exception e) { if (Client.Instance.ClientConnected) Console.WriteLine("server side error", e.ToString()); }

                    s =Send("get", "/instrumentation/gps/indicated-altitude-ft", 0, stream, reader);
                    if (s == "ERR") Console.WriteLine("simulator error"); 
                    else try { ValuesHolder["/instrumentation/gps/indicated-altitude-ft"] = Double.Parse(s);
                    } catch (Exception e) { if (Client.Instance.ClientConnected) Console.WriteLine("server side error", e.ToString()); }

                    s =Send("get", "/instrumentation/attitude-indicator/internal-pitch-deg", 0, stream, reader);
                    if (s == "ERR") Console.WriteLine("simulator error"); 
                    else try { ValuesHolder["/instrumentation/attitude-indicator/internal-pitch-deg"] = Double.Parse(s);
                    } catch (Exception e) { if (Client.Instance.ClientConnected) Console.WriteLine("server side error", e.ToString()); }

                    s =Send("get", "/instrumentation/attitude-indicator/internal-roll-deg", 0, stream, reader);
                    if (s == "ERR") Console.WriteLine("simulator error"); 
                    else try { ValuesHolder["/instrumentation/attitude-indicator/internal-roll-deg"] = Double.Parse(s);
                    } catch (Exception e) { if (Client.Instance.ClientConnected) Console.WriteLine("server side error", e.ToString()); }

                    s =Send("get", "/instrumentation/heading-indicator/indicated-heading-deg", 0, stream, reader);
                    if (s == "ERR") Console.WriteLine("simulator error"); 
                    else try { ValuesHolder["/instrumentation/heading-indicator/indicated-heading-deg"] = Double.Parse(s);
                    } catch (Exception e) { if (Client.Instance.ClientConnected) Console.WriteLine("server side error", e.ToString()); }
        }
        public void SendValues(NetworkStream stream,StreamReader reader) //set all values
        {
                    string s;
                    s=Send("set", "/controls/flight/aileron",ValuesHolder["/controls/flight/aileron"],stream,reader);
                    if(s=="ERR") Console.WriteLine("simulator error");
                    else try { double x=double.Parse(s); }
                    catch (Exception e) { if(Client.Instance.ClientConnected) Console.WriteLine("server side error", e.ToString()); }

                    s =Send("set", "/controls/flight/elevator", ValuesHolder["/controls/flight/elevator"], stream, reader);
                    if (s == "ERR") Console.WriteLine("simulator error");
                    else try { double x = double.Parse(s); }
                    catch (Exception e) { if (Client.Instance.ClientConnected) Console.WriteLine("server side error", e.ToString()); }

                    s =Send("set", "/controls/flight/rudder", ValuesHolder["/controls/flight/rudder"], stream, reader);
                    if (s == "ERR") Console.WriteLine("simulator error");
                    else try { double x = double.Parse(s); }
                    catch (Exception e) { if (Client.Instance.ClientConnected) Console.WriteLine("server side error", e.ToString()); }

                    s =Send("set", "/controls/engines/engine/throttle", ValuesHolder["/controls/engines/current-engine/throttle"], stream, reader);
                    if (s == "ERR") Console.WriteLine("simulator error");
                    else try { double x = double.Parse(s); }
                    catch (Exception e) { if (Client.Instance.ClientConnected) Console.WriteLine("server side error", e.ToString()); }
        }
        public void Run()
        {
            NetworkStream stream = client.GetStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            while (ClientConnected && !EndThreads)
            {
            SendValues(stream,reader);
            UpdateValuesHolder(stream,reader);
            Thread.Sleep(100);
            }
            reader.Close();
            stream.Close();
            ThreadsEnded++;
        }
    }
}
