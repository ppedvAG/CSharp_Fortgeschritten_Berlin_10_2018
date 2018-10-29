using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GoogleBooksClient
{
    public class BoolToStringConverter : IValueConverter
    {
        public string TrueValue { get; set; } = "Buch als Favorit entfernen";
        public string FalseValue { get; set; } = "Buch als Favorit hinzufügen";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is bool boolValue)
            {
                return boolValue ? TrueValue : FalseValue;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString() == TrueValue;
        }
    }
}
