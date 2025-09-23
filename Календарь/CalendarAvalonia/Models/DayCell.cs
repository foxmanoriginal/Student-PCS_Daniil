using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CalendarAvalonia.Models
{
    public partial class DayCell : ObservableObject
    {
        public int? Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public bool IsWeekend { get; set; }
        public bool IsHoliday { get; set; } // true если праздничный день
        public string? HolidayName { get; set; } // название праздника, если есть
        [ObservableProperty]
        private string? note;

        public string? DaysLeftText
        {
            get
            {
                if (Day == null) return null;
                var today = DateTime.Today;
                try
                {
                    var targetDate = new DateTime(Year, Month, Day.Value);
                    int daysLeft = (targetDate - today).Days;
                    if (daysLeft > 0)
                    {
                        if (daysLeft > 365)
                            return "365+";
                        return $"{daysLeft}";
                    }
                    if (daysLeft == 0)
                        return "Сегодня";
                    if (daysLeft < 0)
                        return "";
                }
                catch { }
                return null;
            }
        }
    }
}