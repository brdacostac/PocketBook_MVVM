namespace TP_MVVM.View.Custom;
using CommunityToolkit.Maui.Views;
using System.Windows.Input;

public partial class CustomHeader : ContentView
{
    public static readonly BindableProperty CommandNameProperty = BindableProperty.Create(nameof(CommandName), typeof(ICommand), typeof(CustomHeader));

    public ICommand CommandName
    {
        get => (ICommand)GetValue(CommandNameProperty);
        set => SetValue(CommandNameProperty, value);
    }

    public CustomHeader()
	{
		InitializeComponent();
	}

}