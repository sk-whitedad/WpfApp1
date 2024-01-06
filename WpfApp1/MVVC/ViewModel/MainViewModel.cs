using System.Windows.Input;
using WpfApp1.MVVC.Core;
using WpfApp1.MVVC.Model;
using WpfApp1.Net;

namespace WpfApp1.MVVC.ViewModel
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            ServerClientCommand = new RoutedCommand("ServerClientCommand", typeof(MainWindow));
        }
        public static RoutedCommand ServerClientCommand { get; set; }
    }
}
