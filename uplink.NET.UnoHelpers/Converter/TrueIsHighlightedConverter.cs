using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace uplink.NET.UnoHelpers.Converter
{
    public class TrueIsHighlightedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                bool currentValue = (bool)value;
                if (currentValue)
                    return parameter as Windows.UI.Xaml.Media.SolidColorBrush;
                else
                    return new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Black);
            }
            catch
            {
                return new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Black);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
