using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace WpfApp1.Net.ChatClient
{
    public class NetServer
    {
        public static TcpListener _listener;
        string IpAddress { get; set; }
        string Port { get; set; }

        public NetServer(string ipAddress, string port)
        {
            IpAddress = ipAddress;
            Port = port;
            _listener = new TcpListener(IPAddress.Parse(IpAddress), Int32.Parse(Port));
        }


        public async Task StartServer()
        {
            try
            {
                if (_listener != null)
                {
                    _listener.Start();    // запускаем сервер
                    while (true)
                    {
                        // получаем подключение в виде TcpClient
                        using var tcpClient = await _listener.AcceptTcpClientAsync();
                    }
                }
            }
            finally
            {
                _listener.Stop(); // останавливаем сервер
            }
        }
    }
}

