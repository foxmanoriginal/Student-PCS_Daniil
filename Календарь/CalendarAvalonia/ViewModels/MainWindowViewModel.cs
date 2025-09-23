
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CalendarAvalonia.Models;

namespace CalendarAvalonia.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [RelayCommand]
        private void HideHelp()
        {
            IsHelpVisible = false;
        }
        [ObservableProperty]
        private bool isHelpVisible = true;
        public ObservableCollection<DayCell> Days { get; } = new();
        private static readonly string[] MonthNames =
            CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;

        [ObservableProperty]
        private int currentMonth = DateTime.Now.Month;

        [ObservableProperty]
        private int currentYear = DateTime.Now.Year;

        public string MonthTitle => $"{MonthNames[CurrentMonth - 1]} {CurrentYear}";

        public string[] WeekDays { get; } = new[]
        {
            "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье"
        };

        public MainWindowViewModel()
        {
            GenerateDays();
        }

        public int WeekendAndHolidayCount => Days.Count(d => d.Day.HasValue && (d.IsWeekend || d.IsHoliday));

        public string WeekendAndHolidayCountText => $"Выходных и праздников: {WeekendAndHolidayCount}";

        [RelayCommand]
        private void NextMonth()
        {
            if (CurrentMonth == 12)
            {
                CurrentMonth = 1;
                CurrentYear++;
            }
            else
            {
                CurrentMonth++;
            }
            GenerateDays();
            OnPropertyChanged(nameof(MonthTitle));
        }

        [RelayCommand]
        private void PrevMonth()
        {
            if (CurrentMonth == 1)
            {
                CurrentMonth = 12;
                CurrentYear--;
            }
            else
            {
                CurrentMonth--;
            }
            GenerateDays();
            OnPropertyChanged(nameof(MonthTitle));
        }

        [RelayCommand]
        private void PrevYear()
        {
            CurrentYear--;
            GenerateDays();
            OnPropertyChanged(nameof(MonthTitle));
        }

        [RelayCommand]
        private void NextYear()
        {
            CurrentYear++;
            GenerateDays();
            OnPropertyChanged(nameof(MonthTitle));
        }

        private static readonly (int month, int day, string name)[] Holidays = new[]
        {
            (1, 1, "Новый год"),
            (1, 7, "Рождество"),
            (2, 23, "День защитника Отечества"),
            (3, 8, "Международный женский день"),
            (5, 1, "Праздник Весны и Труда"),
            (5, 9, "День Победы"),
            (6, 12, "День России"),
            (11, 4, "День народного единства"),
        };

        private void GenerateDays()
        {
            Days.Clear();
            var firstDay = new DateTime(CurrentYear, CurrentMonth, 1);
            int daysInMonth = DateTime.DaysInMonth(CurrentYear, CurrentMonth);
            int startDayOfWeek = ((int)firstDay.DayOfWeek + 6) % 7;
            int totalCells = ((daysInMonth + startDayOfWeek) <= 35) ? 35 : 42;
            for (int i = 0; i < startDayOfWeek; i++)
            {
                Days.Add(new DayCell { Day = null, IsWeekend = false, IsHoliday = false, Month = CurrentMonth, Year = CurrentYear });
            }
            for (int d = 1; d <= daysInMonth; d++)
            {
                int dayOfWeek = (startDayOfWeek + d - 1) % 7;
                bool isWeekend = (dayOfWeek == 5 || dayOfWeek == 6);
                var holiday = Array.Find(Holidays, h => h.month == CurrentMonth && h.day == d);
                bool isHoliday = holiday != default || isWeekend;
                string? holidayName = holiday != default ? holiday.name : null;
                Days.Add(new DayCell { Day = d, IsWeekend = isWeekend, IsHoliday = isHoliday, HolidayName = holidayName, Month = CurrentMonth, Year = CurrentYear });
            }
            while (Days.Count < totalCells)
            {
                Days.Add(new DayCell { Day = null, IsWeekend = false, IsHoliday = false, Month = CurrentMonth, Year = CurrentYear });
            }
            OnPropertyChanged(nameof(WeekendAndHolidayCount));
            OnPropertyChanged(nameof(WeekendAndHolidayCountText));
        }
    }
}
