using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Conduit.ViewModel;
using Iciclecreek.Avalonia.WindowManager;

namespace Conduit.Views;

public partial class ManageAppsDialog : ManagedWindow
{
    private AppViewModel? _appViewModel;

    public ManageAppsDialog()
    {
        InitializeComponent();
        Opened += OnOpened;
    }

    private void OnOpened(object? sender, EventArgs e)
    {
        _appViewModel = DataContext as AppViewModel;
        if (_appViewModel != null)
        {
            ToolsListBox.ItemsSource = _appViewModel.Tools;
        }
        SearchBox.Focus();
    }

    private void OnSearchTextChanged(object? sender, TextChangedEventArgs e)
    {
        if (_appViewModel == null) return;

        var searchText = SearchBox.Text ?? string.Empty;
        ToolsListBox.ItemsSource = _appViewModel.Tools.Search(searchText);
    }

    private void OnToolSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (ToolsListBox.SelectedItem is ToolViewModel tool)
        {
            DetailId.Text = tool.Id;
            DetailName.Text = tool.Name;
            DetailDescription.Text = tool.Description;
            DetailVersion.Text = tool.Version;
            DetailCommand.Text = tool.Command;
            DetailArgs.Text = tool.Args;
            DetailInstall.Text = tool.Install;
            DetailUninstall.Text = tool.Uninstall;
            DetailSource.Text = tool.Source;
            DetailDocumentation.Text = tool.Documentation;
            DetailWebsite.Text = tool.Website;
            DetailKeywords.Text = string.Join(", ", tool.Keywords);
            DetailSize.Text = $"{tool.Width}x{tool.Height}";
            
            DetailsContent.IsVisible = true;
        }
        else
        {
            DetailsContent.IsVisible = false;
        }
    }

    private void OnClose(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
