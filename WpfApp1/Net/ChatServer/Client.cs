using System;
using System.Net;
using System.Net.Sockets;

namespace WpfApp1.Net.ChatClient
{
    public class Client
    {
        public static TcpListener _listener;
        string IpAddress { get; set; }
        string Port { get; set; }

        public Client(string ipAddress, string port)
        {
            IpAddress = ipAddress;
            Port = port;
            _listener = new TcpListener(IPAddress.Parse(IpAddress), Int32.Parse(Port));
        }


        public void StartServer()
        {
            if (_listener != null)
            {
                _listener.Start();
                var client = _listener.AcceptTcpClient();
            }
        }


    }
}

