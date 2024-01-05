using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    public class Client
    {
        IPAddress localAddr;
        public Client()
        {
            localAddr = IPAddress.Parse("127.0.0.1");
        }

        public async Task Connect()
        {
            using TcpClient tcpClient = new TcpClient();
            Console.WriteLine("Клиент запущен");
            await tcpClient.ConnectAsync(localAddr, 8888);

            if (tcpClient.Connected)
            {
                // сообщение для отправки
                var message = "Hello METANIT.COM";
                // считыванием строку в массив байт
                byte[] requestData = Encoding.UTF8.GetBytes(message);
                // получаем NetworkStream для взаимодействия с сервером
                var stream = tcpClient.GetStream();
                // отправляем данные
                await stream.WriteAsync(requestData);
                Console.WriteLine("Сообщение отправлено");
            }
            else
                Console.WriteLine("Не удалось подключиться");
        }
    }
}
