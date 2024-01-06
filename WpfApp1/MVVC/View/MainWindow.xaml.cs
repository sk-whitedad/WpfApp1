using System.Text.RegularExpressions;
using System.Windows;
using WpfApp1.MVVC.Model;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private Settings settings;

        public MainWindow()
        {
            this.settings = new Settings { IpAddress = "127.0.0.1", Port = "8888" };
            InitializeComponent();
            this.DataContext = this.settings;
         }

        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            tbChat.Text += $"IpAddress:{settings.IpAddress}; Port:{settings.Port}; IsServer:{settings.IsServer} --- {cbIsChecked.IsChecked}\n";
        }

        private void PreviewPortInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public void TextBox_IP_Error(object sender, System.Windows.Controls.ValidationErrorEventArgs e)
        {
            MessageBox.Show(e.Error.ErrorContent.ToString());
        }

        //@"^((1\d\d|2([0-4]\d|5[0-5])|\d\d?)\.?){4}$"
        //^((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0 - 9])\.){3}(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]?)$
    }
}
