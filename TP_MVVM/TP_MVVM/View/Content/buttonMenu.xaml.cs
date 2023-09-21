using System.Windows.Input;

namespace TP_MVVM.View.Content;

public partial class buttonMenu : ContentView
{

    public static readonly BindableProperty CommandNameProperty = BindableProperty.Create(nameof(CommandName), typeof(ICommand), typeof(buttonMenu));

    public static readonly BindableProperty IconPathProperty = BindableProperty.Create(nameof(IconPath), typeof(string), typeof(buttonMenu));

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(buttonMenu));

    public static readonly BindableProperty CountBookProperty = BindableProperty.Create(nameof(CountBook), typeof(string), typeof(buttonMenu), string.Empty);


    public ICommand CommandName
    {
        get => (ICommand)GetValue(CommandNameProperty);
        set => SetValue(CommandNameProperty, value);
    }

    public string IconPath
    {
        get => (string)GetValue(IconPathProperty);
        set => SetValue(IconPathProperty, value);
    }

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string CountBook
    {
        get => (string)GetValue(CountBookProperty);
        set => SetValue(CountBookProperty, value);
    }


    public buttonMenu()
	{
		InitializeComponent();
	}
}