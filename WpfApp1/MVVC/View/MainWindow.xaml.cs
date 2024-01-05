using System.Windows;
using WpfApp1.MVVC.Model;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private Settings settings;

        public MainWindow()
        {
            this.settings = new Settings();
            InitializeComponent();
            settings.IpAddress = "127.0.0.1";
            settings.Port = "8888";
            this.DataContext = this.settings;
         }

        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            tbChat.Text += $"IpAddress:{settings.IpAddress}; Port:{settings.Port}; IsServer:{settings.IsServer} --- {cbIsChecked.IsChecked}\n";
        }
           
    }
}
