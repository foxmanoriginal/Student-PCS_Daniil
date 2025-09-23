using System;
using System.Collections.Generic;

namespace CalendarAvalonia.Models
{
    public class MonthPage
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public List<int?> Days { get; set; } = new(); // null = пустая ячейка
    }
}
