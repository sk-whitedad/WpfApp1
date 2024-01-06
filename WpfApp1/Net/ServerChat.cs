using System;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.MVVC.ViewModel;

namespace WpfApp1.Net
{
     public class ServerChat
     {
        public static TcpListener _listener;
        public ServerChat()
        {
            _listener = new TcpListener(IPAddress.Parse(MainWindow.settings.IpAddress), Int32.Parse(MainWindow.settings.Port));
        }


        public void StartServer()
        {
            if(_listener != null)
            {
                _listener.Start();
                var client = _listener.AcceptTcpClient();
            }
        }


    }
}

