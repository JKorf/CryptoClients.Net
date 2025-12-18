using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using CryptoVisualizer.Net.ViewModels;

namespace CryptoVisualizer.Net;

public partial class Chart : UserControl
{
    public Chart()
    {
        InitializeComponent();
    }

    protected override void OnUnloaded(RoutedEventArgs e)
    {
        _ = (DataContext as ChartViewModel)!.UnloadAsync();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void ComboBox_ActualThemeVariantChanged(object? sender, System.EventArgs e)
    {
    }
}