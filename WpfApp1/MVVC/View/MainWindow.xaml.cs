using System.Text.RegularExpressions;
using System.Windows;
using WpfApp1.MVVC.Model;
using WpfApp1.MVVC.ViewModel;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private MainViewModel mainViewModel;
        public MainWindow()
        {
            mainViewModel = new MainViewModel();
            InitializeComponent();
            this.DataContext = mainViewModel;
        }

         private void PreviewPortInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btSend_Click(object sender, RoutedEventArgs e)
        {
            tbChat.Text += $"IP адрес:{mainViewModel.IpAddress} / Порт:{mainViewModel.Port} / Сервер:{mainViewModel.IsServer}\n";
            mainViewModel.IpAddress = "120.120.120.120";
            tbChat.Text += $"IP адрес:{tbIpAddress.Text} / Порт:{mainViewModel.Port} / Сервер:{mainViewModel.IsServer}\n";

        }
    }
}
