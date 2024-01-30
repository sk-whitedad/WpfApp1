using System;
using System.Net;
using System.Net.Sockets;
using TcpServer;
using TcpServer.Net;

namespace WpfApp1.Net.ChatServer
{
    public class NetClient
    {
        public static Contr? contr;
        IPEndPoint endp;
        public ServerObj server;

        public NetClient(string ipAddress, string port)
        {
            endp = new IPEndPoint(IPAddress.Parse(ipAddress), Convert.ToInt32(port));
        }

        public async void ConnectToServer()
        {
            contr = new Contr();
            server = contr.GetServer(endp);
            server.Start();
            while (true)
            {
                var msg = Console.ReadLine();
                if (!string.IsNullOrEmpty(msg))
                    await server.SendMessageAsync(msg);
            }

        }
    }
}
