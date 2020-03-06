using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using XamarinDemo.Common;

namespace XamarinDemo.ValueConverters
{
    public class PrependBaseURLToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return AppConstants.WebURLs.ServerURL + value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
