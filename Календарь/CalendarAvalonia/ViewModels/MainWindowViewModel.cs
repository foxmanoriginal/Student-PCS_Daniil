using System;
using System.Collections.ObjectModel;
using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CalendarAvalonia.Models;

namespace CalendarAvalonia.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        // Коллекция: для каждого дня true, если это выходной (суббота/воскресенье), иначе false
    // Коллекция дней месяца с признаком выходного
    public ObservableCollection<DayCell> Days { get; } = new();
    // Массив названий месяцев для отображения заголовка
    private static readonly string[] MonthNames =
        CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;


    // Текущий месяц (1-12)
    [ObservableProperty]
    private int currentMonth = DateTime.Now.Month;

    // Текущий год
    [ObservableProperty]
    private int currentYear = DateTime.Now.Year;

    // Заголовок месяца (например, "Сентябрь 2025")
    public string MonthTitle => $"{MonthNames[CurrentMonth - 1]} {CurrentYear}";



    // Названия дней недели
    public string[] WeekDays { get; } = new[]
    {
        "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье"
    };

    // Конструктор: генерирует сетку дней для текущего месяца
    public MainWindowViewModel()
    {
        GenerateDays();
    }


    // Команда: следующий месяц
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
        GenerateDays(); // Перегенерировать сетку дней
        OnPropertyChanged(nameof(MonthTitle));
    }


    // Команда: предыдущий месяц
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
        GenerateDays(); // Перегенерировать сетку дней
        OnPropertyChanged(nameof(MonthTitle));
    }

    // Генерирует коллекцию Days для текущего месяца
    private void GenerateDays()
    {
        Days.Clear();
        var firstDay = new DateTime(CurrentYear, CurrentMonth, 1);
        int daysInMonth = DateTime.DaysInMonth(CurrentYear, CurrentMonth);
        int startDayOfWeek = ((int)firstDay.DayOfWeek + 6) % 7;
        int totalCells = ((daysInMonth + startDayOfWeek) <= 35) ? 35 : 42;
        for (int i = 0; i < startDayOfWeek; i++)
        {
            Days.Add(new DayCell { Day = null, IsWeekend = false });
        }
        for (int d = 1; d <= daysInMonth; d++)
        {
            int dayOfWeek = (startDayOfWeek + d - 1) % 7;
            Days.Add(new DayCell { Day = d, IsWeekend = (dayOfWeek == 5 || dayOfWeek == 6) });
        }
        while (Days.Count < totalCells)
        {
            Days.Add(new DayCell { Day = null, IsWeekend = false });
        }
    }

    }
}
