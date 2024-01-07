using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using WpfApp1.MVVC.Core;
using WpfApp1.MVVC.Model;
using WpfApp1.Net;
using WpfApp1.Net.ChatClient;
using WpfApp1.Net.ChatServer;

namespace WpfApp1.MVVC.ViewModel
{
    public class MainViewModel: INotifyPropertyChanged
    {
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

        //метод обработки команды нажатия на кнопку Старт/Подключение
        public async void StartConnectMethod()
        {
            if(IsServer)
            {
                ClientOrServer = "Сервер";
                Client client = new Client(IpAddress, Port);
                await client.StartServer();
            }
            else
            {
                ClientOrServer = "Клиент";
                Server server = new Server(IpAddress, Port);
                server.ConnectToServer();
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
