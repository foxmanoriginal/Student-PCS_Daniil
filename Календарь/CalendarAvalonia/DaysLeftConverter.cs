using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace CalendarAvalonia
{
    public class DaysLeftConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            // value — это Day, а dataContext — DayCell
            if (value is int day)
            {
                // dataContext будет DayCell, если биндинг идёт по свойству Day
                // Avalonia не передаёт dataContext напрямую, но мы можем получить Month/Year из DayCell через binding
                // Поэтому используем value как Day, а parameter не используем
                // В XAML DayCell.Day всегда принадлежит DayCell, Month/Year уже есть
                // Получаем DayCell через binding: {Binding .}
                // Но в IValueConverter нет доступа к dataContext, поэтому лучше сделать отдельный DaysLeftText property в DayCell
                // Но для совместимости:
                // value — это Day, targetType — string, parameter — null
                // Попробуем получить Month/Year через value
                // Если value — DayCell, то используем его
                // Но сейчас value — int, поэтому не можем получить Month/Year
                // Решение: сделать отдельный DaysLeftText property в DayCell
                return null;
            }
            return null;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
