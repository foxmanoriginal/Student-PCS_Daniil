using Avalonia.Data.Converters;
using Avalonia;
using Avalonia.Controls;
using System;
using System.Globalization;

namespace CalendarAvalonia
{
    public class NoteVisibilityConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            bool visible = value is string s && !string.IsNullOrWhiteSpace(s);
            return visible;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
