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
    // HolidayBgConverter: тёмно-оранжевый для праздников, тёмно-фиолетовый для выходных, иначе null
    using CalendarAvalonia.Models;
    public class HolidayBgConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is DayCell cell)
            {
                if (!string.IsNullOrEmpty(cell.HolidayName))
                    return new SolidColorBrush(Color.Parse("#C1440E")); // тёмно-оранжевый
                if (cell.IsWeekend)
                    return new SolidColorBrush(Color.Parse("#4B006E")); // тёмно-фиолетовый
            }
            return null;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
