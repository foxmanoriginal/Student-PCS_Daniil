using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Threading.Tasks;

namespace CalendarAvalonia.Views
{
    public partial class NoteDialog : Window
    {
        public string? NoteText { get; private set; }

        public NoteDialog() // нужен для Avalonia XAML loader
        {
            InitializeComponent();
            this.FindControl<Button>("OkButton").Click += OkButton_Click;
            this.FindControl<Button>("CancelButton").Click += CancelButton_Click;
        }

        public NoteDialog(string? initialText) : this()
        {
            this.FindControl<TextBox>("NoteBox").Text = initialText;
        }

        private void OkButton_Click(object? sender, RoutedEventArgs e)
        {
            NoteText = this.FindControl<TextBox>("NoteBox").Text;
            Close(NoteText);
        }

        private void CancelButton_Click(object? sender, RoutedEventArgs e)
        {
            Close(null);
        }

        public static async Task<string?> ShowDialog(Window parent, string? initialText = null)
        {
            var dlg = new NoteDialog(initialText);
            return await dlg.ShowDialog<string?>(parent);
        }
    }
}
