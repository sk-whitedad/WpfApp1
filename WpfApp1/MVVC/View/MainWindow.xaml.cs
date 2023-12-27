using System;
using System.Collections.Generic;
using System.Linq;
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
        public MainWindow()
        {
            InitializeComponent();
            if (!(bool)(cbServer.IsChecked))
            {
                lbStatusConnect.Content = "";
                role = Role.Client;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if((sender as Button).Content == "Join")
            {
                //подключение
            }
            if ((sender as Button).Content.Equals("Send"))
            {
                if (tbMessageText.Text != "")
                    tbChatText.Text += $"{role.ToString()}: {tbMessageText.Text} \r";
                tbMessageText.Text = "";
            }
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            lbStatusConnect.Visibility = Visibility.Hidden;
            btJoin.Visibility = Visibility.Hidden; 
            role = Role.Server;
        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            lbStatusConnect.Visibility = Visibility.Visible;
            btJoin.Visibility = Visibility.Visible;
            lbStatusConnect.Content = "Status: disconnected";
            role = Role.Client;
        }
    }
}
