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
        private string ipAddress;
        private string port;
        private bool isServer;

        public string IpAddress {  get { return ipAddress; } set {  ipAddress = value; } }
        public string Port { get { return port; } set { port = value; } }
        public bool IsServer { get {  return isServer; } set {  isServer = value; } }
    }
}
