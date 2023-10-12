namespace TP_MVVM.View.Content;

public partial class buttonBook : ContentView
{
    public static readonly BindableProperty BookImageProperty = BindableProperty.Create(nameof(BookImage), typeof(string), typeof(buttonBook));
    public static readonly BindableProperty BookNameProperty = BindableProperty.Create(nameof(BookName), typeof(string), typeof(buttonBook));
    public static readonly BindableProperty BookAuteurProperty = BindableProperty.Create(nameof(BookAuteur), typeof(string), typeof(buttonBook));
    public static readonly BindableProperty StatusProperty = BindableProperty.Create(nameof(Status), typeof(string), typeof(buttonBook));


    public string BookImage
    {
        get => (string)GetValue(BookImageProperty);
        set => SetValue(BookImageProperty, value);
    }

    public string BookName
    {
        get => (string)GetValue(BookNameProperty);
        set => SetValue(BookNameProperty, value);
    }

    public string BookAuteur
    {
        get => (string)GetValue(BookAuteurProperty);
        set => SetValue(BookAuteurProperty, value);
    }

    public string Status
    {
        get => (string)GetValue(StatusProperty);
        set => SetValue(StatusProperty, value);
    }

    

    public buttonBook()
	{
		InitializeComponent();
	}
}