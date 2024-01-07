using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.MVVC.Model
{
    public class DataWorker
    {
        //получение настроек 
        public static Settings GetSettings() 
        { 
            return new Settings { IpAddress = "127.0.0.1", Port = "8888", IsServer = false }; 
        }

    }
}
