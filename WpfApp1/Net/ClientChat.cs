using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections;
using System.Net.Http;
using WpfApp1.MVVC.ViewModel;

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
            if (!_client.Connected)
            {
                _client.Connect(IPAddress.Parse(MainWindow.settings.IpAddress), Int32.Parse(MainWindow.settings.Port));
            }
        }
    }
}
