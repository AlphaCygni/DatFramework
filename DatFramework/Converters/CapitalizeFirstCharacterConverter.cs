using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DatFramework.Converters
{
    [ValueConversion(typeof(string), typeof(string))]
    public class CapitalizeFirstCharacterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
            {            
                var s = (string)value;

                if (!string.IsNullOrEmpty(s))
                {
                    return char.ToUpper(s[0]) + (s.Length > 1 ? s.Substring(1) : "");
                }
            }            

            return value;
        }
    }
}
