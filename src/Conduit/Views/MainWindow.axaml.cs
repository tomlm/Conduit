using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Conduit.Controls;

namespace Conduit.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnExit(object sender, RoutedEventArgs e)
        {
            this.Close();

            //var lifetime = Application.Current!.ApplicationLifetime as IControlledApplicationLifetime;
            //lifetime!.Shutdown();
        }

        private void OnNewClicked(object? sender, RoutedEventArgs e)
        {
            var terminalWindow = new ManagedTerminalWindow
            {
                Width = 80,
                Height = 25,
                FontFamily = "Cascadia Mono",
                CloseOnProcessExit = true
            };
            terminalWindow.Show(Windows);
        }


        private async void OnStartClicked(object? sender, RoutedEventArgs e)
        {
            var dialog = new CommandLineDialog();
            var result = await dialog.ShowDialog<bool?>(this);

            if (result == true && !string.IsNullOrWhiteSpace(dialog.CommandLine))
            {
                var commandLine = dialog.CommandLine.Trim();
                var parts = ParseCommandLine(commandLine);
                var process = parts.Count > 0 ? parts[0] : commandLine;
                var args = parts.Count > 1 ? parts.GetRange(1, parts.Count - 1) : [];

                var terminalWindow = new ManagedTerminalWindow
                {
                    Process = process,
                    Args = args,
                    Title = process,
                    Width = 80 ,
                    Height = 25 ,
                    FontFamily = "Cascadia Mono",
                    CloseOnProcessExit = true
                };
                terminalWindow.Show(Windows);
            }
        }



        private static List<string> ParseCommandLine(string commandLine)
        {
            var args = new List<string>();
            var current = "";
            var inQuotes = false;

            foreach (var c in commandLine)
            {
                if (c == '"')
                {
                    inQuotes = !inQuotes;
                }
                else if (c == ' ' && !inQuotes)
                {
                    if (!string.IsNullOrEmpty(current))
                    {
                        args.Add(current);
                        current = "";
                    }
                }
                else
                {
                    current += c;
                }
            }

            if (!string.IsNullOrEmpty(current))
            {
                args.Add(current);
            }

            return args;
        }
    }
}