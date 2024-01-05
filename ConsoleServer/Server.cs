using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleServer
{
    public class Server
    {
        IPAddress localAddr;
        TcpListener tcpListener;
        public Server()
        {
            localAddr = IPAddress.Parse("127.0.0.1");
        }

        public async Task StartServer()
        {
            tcpListener = new TcpListener(localAddr, 8888);
            tcpListener.Start();
            try
            {
                tcpListener.Start();    // запускаем сервер
                Console.WriteLine("Сервер запущен. Ожидание подключений... ");

                while (true)
                {
                    // получаем подключение в виде TcpClient
                    using var tcpClient = await tcpListener.AcceptTcpClientAsync();
                    // получаем объект NetworkStream для взаимодействия с клиентом
                    var stream = tcpClient.GetStream();
                    // определяем буфер для получения данных
                    byte[] responseData = new byte[1024];
                    int bytes = 0; // количество считанных байтов
                    var response = new StringBuilder(); // для склеивания данных в строку
                                                        // считываем данные 
                    do
                    {
                        bytes = await stream.ReadAsync(responseData);
                        response.Append(Encoding.UTF8.GetString(responseData, 0, bytes));
                    }
                    while (bytes > 0);
                    // выводим отправленные клиентом данные
                    Console.WriteLine(response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                tcpListener.Stop(); // останавливаем сервер
            }
        }



    }
}
