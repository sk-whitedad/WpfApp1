using System;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.MVVC.Model
{
    public enum StatusClient
    {
        Connected,
        Disconnected,
        Eror
    }

    public class ClientChat
    {
        TcpClient? tcpClient { get; set; }
        IPAddress? localAddr { get; set; }
        StatusClient statusClient;

        public ClientChat(string ip)
        {
            localAddr = IPAddress.Parse(ip);
        }
        public async Task Connected()
        {
            using TcpClient tcpClient = new TcpClient();
            try
            {
                if (tcpClient != null && localAddr != null)
                   await tcpClient.ConnectAsync(localAddr, 8888);
            }
            catch (SocketException ex)
            {
                //обрабатываем ошибку подключения
                statusClient = StatusClient.Eror;
            }
        }

        public async Task SendMessage(string str)
        {
            if (tcpClient != null && str !="")
            {
                NetworkStream stream = tcpClient.GetStream();
                var requestData = Encoding.UTF8.GetBytes(str);
                await stream.WriteAsync(requestData);
            }

        }


        public void Close()
        {
            if(tcpClient != null)
            tcpClient.Close();      // закрываем подключение
        }

        public StatusClient GetStatus()
        {
            if (tcpClient != null && tcpClient.Connected)
                return StatusClient.Connected;
            else if (tcpClient != null && !tcpClient.Connected)
                return StatusClient.Disconnected;
            else return StatusClient.Eror;
        }


    }
}

