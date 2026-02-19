using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace KickBlastJudo;

public partial class MainWindow : Window
{
    private readonly Dictionary<string, Grid> _views;
    private readonly Dictionary<string, Button> _buttons;

    public MainWindow()
    {
        InitializeComponent();
        CurrentDateText.Text = DateTime.Now.ToString("dddd, dd MMM yyyy");

        _views = new Dictionary<string, Grid>
        {
            ["Dashboard"] = DashboardView,
            ["Athletes"] = AthletesView,
            ["Calculator"] = CalculatorView,
            ["History"] = HistoryView,
            ["Settings"] = SettingsView
        };

        _buttons = new Dictionary<string, Button>
        {
            ["Dashboard"] = DashboardButton,
            ["Athletes"] = AthletesButton,
            ["Calculator"] = CalculatorButton,
            ["History"] = HistoryButton,
            ["Settings"] = SettingsButton
        };

        SetPage("Dashboard");
    }

    private void Navigate_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.Tag is string page)
        {
            SetPage(page);
        }
    }

    private void SetPage(string page)
    {
        foreach (var view in _views.Values)
        {
            view.Visibility = Visibility.Collapsed;
        }

        foreach (var navButton in _buttons.Values)
        {
            navButton.Background = Brushes.Transparent;
        }

        _views[page].Visibility = Visibility.Visible;
        _buttons[page].Background = (Brush)FindResource("PrimaryTealBrush");
        PageTitleText.Text = page;
    }
}
