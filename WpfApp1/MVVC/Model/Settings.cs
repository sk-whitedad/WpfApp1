using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1.MVVC.Model
{
    public class Settings
    {
        public string IpAddress {  get; set; }
        public string Port { get; set; }
        public bool IsServer { get; set; }
    }
}
