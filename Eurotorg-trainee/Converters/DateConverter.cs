using System;
using System.Globalization;
using System.Windows.Data;

using Eurotorg_trainee.Helpers;

namespace Eurotorg_trainee.Converters
{
    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DateToString.Convert((DateTime)value, "dd.MM.yyyy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
