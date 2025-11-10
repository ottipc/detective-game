using Avalonia.Controls;
using Detektivspiel.Controllers;
using System.Linq;

namespace Detektivspiel.Views
{
    public partial class MainWindow : Window
    {
        private readonly GameController _controller = new();

        public MainWindow()
        {
            InitializeComponent();
            StartButton.Click += StartGame;
            GuessButton.Click += GuessMurderer;
        }

        private void StartGame(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            _controller.Init();
            OutputBox.Items.Clear();
            foreach (var s in _controller.Suspects)
                OutputBox.Items.Add($"Verdächtiger: {s.Name} – Motiv: {s.Motiv}");

            SuspectBox.ItemsSource = _controller.GetSuspectNames().ToList();
            SuspectBox.SelectedIndex = 0;
            SuspectBox.IsEnabled = true;
            GuessButton.IsEnabled = true;
            ResultText.Text = "Wähle einen Verdächtigen und rate!";
        }

        private void GuessMurderer(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (SuspectBox.SelectedItem is string name)
            {
                string result = _controller.CheckGuess(name);
                ResultText.Text = result;
            }
        }
    }
}
