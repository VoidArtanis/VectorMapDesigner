using System;
using System.Globalization;
using System.Windows.Data;

namespace Imagio.Converter
{
    public class PercentageToDecimal : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return System.Convert.ToSingle(value)/100;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return System.Convert.ToSingle(value)*100;
        }
    }
}