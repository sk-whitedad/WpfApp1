using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.MVVC.Model;

namespace WpfApp1
{
    enum Role { Server, Client }
    public enum Status { Started, Stopped, Reception, Error}

    public interface IGetStatusServer
    {
        public Status status { get; set; }
        public string Message { get; set; }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IGetStatusServer
    {
        Role role;
        ServerChat server { get; set; }
        ClientChat client { get; set; }
        public Status status { get; set; }
        public string Message { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            server = new ServerChat(tbIPaddr.Text, this);
            client = new ClientChat(tbIPaddr.Text);
            if (cbServer.IsChecked == false && cbServer.IsChecked == null)
            {
                role = Role.Client;
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            lbStatusConnect.Content = "";
            if (((Button)sender as Button).Content.Equals("Connect"))
            {
                //подключение клиента
                await client.Connected();
                    //bStatusConnect.Content = $"Connected to server:{tbIPaddr.Text}";
                    btJoin.Content = "Disconnect";
                    cbServer.IsEnabled = false;
                    tbIPaddr.IsEnabled = false;
                    tbName.IsEnabled = false;
            }
            else if(((Button)sender as Button).Content.Equals("Disconnect"))
            {
                //отключение клиента
                client.Close();
                btJoin.Content = "Connect";
                cbServer.IsEnabled = true;
                tbIPaddr.IsEnabled = true;
                tbName.IsEnabled = true;
            }

            if (((Button)sender as Button).Content.Equals("Start"))
            {
                //старт сервера
                btJoin.Content = "Stop";
                cbServer.IsEnabled = false;
                tbIPaddr.IsEnabled = false;
                if(status == Status.Started)
                    lbStatusConnect.Content = $"Server started: {tbIPaddr.Text}";
                await server.StartServer();

            }
            else if (((Button)sender as Button).Content.Equals("Stop"))
            {
                //стоп сервера
                server.StopServer();
                btJoin.Content = "Start";
                cbServer.IsEnabled = true;
                tbIPaddr.IsEnabled = true;
                if (status == Status.Stopped)
                    lbStatusConnect.Content = $"Server stopped: {tbIPaddr.Text}";
            }

            if (((Button)sender as Button).Content.Equals("Send"))
            {
                if (tbMessageText.Text != "")
                {
                    tbChatText.Text += $"{role.ToString()}: {tbMessageText.Text} \r";
                    await client.SendMessage(tbMessageText.Text);
                }
                tbMessageText.Text = "";
            }
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            role = Role.Server;
            btJoin.Content = "Start";
            tbName.IsEnabled = false;
            lbStatusConnect.Content = "";
        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            role = Role.Client;
            btJoin.Content = "Connect";
            tbName.IsEnabled = true;
            lbStatusConnect.Content = "";
        }

     
    }
}
