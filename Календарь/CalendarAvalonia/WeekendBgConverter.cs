using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Globalization;

namespace CalendarAvalonia
{
    using System.Collections.ObjectModel;
    using System.Collections;
    using Avalonia.Data;
    using System.Linq;
    public class WeekendBgConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is bool isWeekend && isWeekend)
                return new SolidColorBrush(Color.Parse("#E0F4FF"));
            return null;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
