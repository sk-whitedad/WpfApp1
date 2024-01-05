using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
