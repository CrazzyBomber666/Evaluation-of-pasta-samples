using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Data;

namespace WpfApp1
{
    class DecimalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return value.ToString().Replace(",", ".");
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //int strLimit = 3;
            try
            {
                float temp = System.Convert.ToSingle(value.ToString().Replace(".", ","));
                string strVal = value.ToString().Replace(".", ",");
                if (temp <= 100)
                {
                    if (strVal.Length >= 5)
                    {
                        return strVal.Replace(",", ".").Substring(0, 4);
                    }
                }
                else
                {
                    return strVal.Replace(",", ".").Substring(0, 2);
                }
            }
            catch { }
            if (value != null)
                return value.ToString().Replace(",", ".");
            else return null;
        }
    }
}
