using Avalonia.Controls;
using Avalonia.Input;
using CalendarAvalonia.Models;
using System.Threading.Tasks;

namespace CalendarAvalonia.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void DayCell_PointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (sender is StackPanel panel && panel.DataContext is DayCell cell && cell.Day.HasValue)
        {
            var note = await NoteDialog.ShowDialog(this, cell.Note);
            if (note != null)
                cell.Note = note;
        }
    }
}