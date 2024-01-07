using System;
using System.Net;
using System.Net.Sockets;

namespace WpfApp1.Net.ChatServer
{
    public class Server
    {
        TcpClient _client;
        string IpAddress { get; set; }
        string Port { get; set; }

        public Server(string ipAddress, string port)
        {
            IpAddress = ipAddress;
            Port = port;
            _client = new TcpClient();
        }

        public void ConnectToServer()
        {
            if (!_client.Connected)
            {
                _client.Connect(IPAddress.Parse(IpAddress), Int32.Parse(Port));
            }
        }
    }
}
