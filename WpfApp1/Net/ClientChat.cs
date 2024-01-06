using System;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Net
{
     public class ClientChat
    {
        TcpClient _client;
        public ClientChat()
        {
            _client = new TcpClient();
        }

        public void ConnectToServer()
        {
            if(!_client.Connected)
            {
                _client.Connect("127.0.0.1", 8888);
            }
        }
     }
}

