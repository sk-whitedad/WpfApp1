using System.Text.RegularExpressions;
using System.Windows;
using WpfApp1.MVVC.Model;
using WpfApp1.MVVC.ViewModel;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public static Settings settings {  get; set; }
        public MainWindow()
        {
            settings = new Settings { IpAddress = "127.0.0.1", Port = "8888" };
            InitializeComponent();
            this.DataContext = settings;
        }

         private void PreviewPortInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public void ServerClientExecute(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            if (settings.IsServer)
                MessageBox.Show("Запуск сервера");
            else
                MessageBox.Show("Запуск клиента");
        }
    }
}
