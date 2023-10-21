using System.Windows.Input;

namespace TP_MVVM.View.Content;

public partial class buttonOptionsBookDetail : ContentView
{

    public static readonly BindableProperty CommandNameProperty = BindableProperty.Create(nameof(CommandName), typeof(ICommand), typeof(buttonOptionsBookDetail));

    public static readonly BindableProperty CommandNameParameterProperty = BindableProperty.Create(nameof(CommandNameParameter), typeof(object), typeof(buttonOptionsBookDetail));
   


    public static readonly BindableProperty IconPathProperty = BindableProperty.Create(nameof(IconPath), typeof(string), typeof(buttonOptionsBookDetail));

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(buttonOptionsBookDetail));



    public ICommand CommandName
    {
        get => (ICommand)GetValue(CommandNameProperty);
        set => SetValue(CommandNameProperty, value);
    }

    public object CommandNameParameter
    {
        get => (object)GetValue(CommandNameParameterProperty);
        set => SetValue(CommandNameParameterProperty, value);
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


    public buttonOptionsBookDetail()
	{
		InitializeComponent();
	}
}