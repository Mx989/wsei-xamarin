using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace AirMonitor.ViewModels.Helpers
{
    class PercentConverter : IValueConverter
    {
        int? input = 0;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            input = value as int?;
            
            return string.Format("{0}%", input);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return input;
        }
  

    }
}

