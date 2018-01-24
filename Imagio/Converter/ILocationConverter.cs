using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Imagio.Converter
{
    public class LocationConverter : IValueConverter
    {
        private readonly bool returnY;

        public LocationConverter(bool returnY)
        {
            this.returnY = returnY;
        }

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (returnY)
            {
                var h = (parameter as UIElement).RenderSize.Height;
                if (h > 0)
                {
                    var v = (double) value + (parameter as UIElement).RenderSize.Height/2;
                    return returnY ? v : v;
                }
            }
            else
            {
                var w = (parameter as UIElement).RenderSize.Width;
                if (w > 0)
                {
                    var v = (double) value + (parameter as UIElement).RenderSize.Width/2;
                    return returnY ? v : v;
                }
            }
            return (double) value + 5;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}