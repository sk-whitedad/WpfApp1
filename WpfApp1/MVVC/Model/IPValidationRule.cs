using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1.MVVC.Model
{
    public class IPValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string str = value.ToString();
            if (str == "")
               return new ValidationResult(true, null);
           var regex = new Regex("^\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}$");
           if (!regex.IsMatch(str))
               return new ValidationResult(false, "Ошибка ввода");
           else
               return new ValidationResult(true, null);
        }
    }
}
