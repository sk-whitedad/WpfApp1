using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.MVVC.Model;
using WpfApp1.MVVC.ViewModel;
using WpfApp1.Net.ChatServer;

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
    }
}
