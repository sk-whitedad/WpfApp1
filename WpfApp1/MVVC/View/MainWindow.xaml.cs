﻿using System;
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

enum Role
{
    Server,
    Client
}

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Role role;
        ServerChat server { get; set; }
        ClientChat client { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            if (!(bool)(cbServer.IsChecked))
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
                if(client == null)
                    client = new ClientChat(tbIPaddr.Text);

                await client.Connected();

                if (client.GetStatus() == StatusClient.Connected)
                {
                    lbStatusConnect.Content = $"Connected to server: {tbIPaddr.Text}";
                    btJoin.Content = "Disconnect";
                    cbServer.IsEnabled = false;
                    tbIPaddr.IsEnabled = false;
                    tbName.IsEnabled = false;
                }
                else if (client.GetStatus() == StatusClient.Disconnected)
                    lbStatusConnect.Content = $"Connection failed.";
                else lbStatusConnect.Content = $"Not responding";
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
                server = new ServerChat(tbIPaddr.Text);
                await server.StartServer();
                btJoin.Content = "Stop";
                cbServer.IsEnabled = false;
                tbIPaddr.IsEnabled = false;
                lbStatusConnect.Content = $"Server started: {tbIPaddr.Text}";
            }
            else if (((Button)sender as Button).Content.Equals("Stop"))
            {
                //стоп сервера
                server.StopServer();
                btJoin.Content = "Start";
                cbServer.IsEnabled = true;
                tbIPaddr.IsEnabled = true;
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
