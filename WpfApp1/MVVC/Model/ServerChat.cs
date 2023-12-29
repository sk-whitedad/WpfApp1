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

namespace WpfApp1.MVVC.Model
{
    public class ServerChat
    {
        IPAddress? localAddr { get; set; }
        TcpListener? server { get; set; }
        public IGetStatusServer StatusServer { get; set; }

        public ServerChat(string ip, IGetStatusServer statusServer)
        {
            localAddr = IPAddress.Parse(ip);
            StatusServer = statusServer;
        }
        
         public async Task StartServer()
        {
            server = new TcpListener(localAddr, 8888);
            try
            {
                if (server != null)
                {
                    server.Start();    // запускаем сервер
                   while (true)
                    {
                        using var tcpClient = await server.AcceptTcpClientAsync();
                        StatusServer.status = Status.Started;
                        var stream = tcpClient.GetStream();
                        byte[] responseData = new byte[1024];
                        int bytes = 0; // количество считанных байтов
                        var response = new StringBuilder(); // для склеивания данных в строку
                        // считываем данные 
                        do
                        {
                            StatusServer.status = Status.Reception;
                            bytes = await stream.ReadAsync(responseData);
                            response.Append(Encoding.UTF8.GetString(responseData, 0, bytes));
                        }
                        while (bytes > 0);
                        // выводим отправленные клиентом данные
                        StatusServer.Message = response.ToString();
                        
                    }
                }
            }
            finally
            {
                StatusServer.status = Status.Stopped;
                if (server != null)
                    server.Stop(); // останавливаем сервер
            }
        }

        public void StopServer()
        {
            StatusServer.status = Status.Stopped;
            server.Stop(); // останавливаем сервер
        }

    }
}
