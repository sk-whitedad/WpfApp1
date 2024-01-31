using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using TcpServer.Net;
using TcpServer;
using WpfApp1.MVVC.Core;
using WpfApp1.MVVC.Model;
using System.Windows.Interop;
using ClientTcp.Net;
using System;
using Dop.Interfaces;

namespace WpfApp1.MVVC.ViewModel
{
    public class MainViewModel: INotifyPropertyChanged, IComm
    {
        ServerObj server;
        ClientObj client;
        Contr contr;
        ServerObj serverObj;

        private Settings settings = DataWorker.GetSettings();
        public string IpAddress 
        {  
            get { return settings.IpAddress; }
            set { settings.IpAddress = value; NotifyPropertyChanged(nameof(IpAddress));}
        }
        public string Port
        {
            get { return settings.Port; }
            set { settings.Port = value; NotifyPropertyChanged(nameof(Port)); }
        }
        public bool IsServer
        {
            get { return settings.IsServer; }
            set { settings.IsServer = value; NotifyPropertyChanged(nameof(IsServer)); }
        }
        private string clientOrServer;
        public string ClientOrServer
        {
            get { return clientOrServer; }
            set { clientOrServer = value; NotifyPropertyChanged(nameof(ClientOrServer)); }
        }

        private string stringMessage;
        public string StringMessage
        {
            get { return stringMessage; }
            set { stringMessage = value; NotifyPropertyChanged(nameof(StringMessage)); }
        }

        private string stringChat;
        public string StringChat
        {
            get { return stringChat; }
            set { stringChat = value; NotifyPropertyChanged(nameof(StringChat)); }
        }

        //метод обработки команды нажатия на кнопку Старт/Подключение
        public async void StartConnectMethod()
        {
            if(IsServer)
            {
                IPEndPoint endp = new IPEndPoint(IPAddress.Any, Convert.ToInt32(Port));
                server = new(endp, this);
                server.Start();
            }
            else
            {
                IPEndPoint endp = new IPEndPoint(IPAddress.Parse(IpAddress), Convert.ToInt32(Port));
                client = new(endp, this);
                await client.Connect();
            }
        }

        //команда нажатия кнопки Старт/Подключение
        private RelayCommand clickStartConnectButton;
        public RelayCommand ClickStartConnectButton
        {
            get
            {
                return clickStartConnectButton ?? new RelayCommand(obj =>
                {
                    StartConnectMethod();
                });
            }
        }

        //метод обработки команды нажатия на кнопку Старт/Подключение
        public async void SendMessageButton()
        {
            if (!string.IsNullOrEmpty(StringMessage))
            {
                if (IsServer)
                {
                    await server.SendMessageAsync(StringMessage);
                    StringChat += $"{StringMessage}\n";
                }
                else
                {
                    await client.SendMessageAsync(StringMessage);
                    StringChat += $"{StringMessage}\n";
                }
            }
        }

        //команда отправки сообщения кнопки Send
        private RelayCommand clickSendMessageButton;
        public RelayCommand ClickSendMessageButton
        {
            get
            {
                return clickSendMessageButton ?? new RelayCommand(obj =>
                {
                    SendMessageButton();
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Message(string msg)
        {
            StringChat += msg + "\n";
        }
    }
}
