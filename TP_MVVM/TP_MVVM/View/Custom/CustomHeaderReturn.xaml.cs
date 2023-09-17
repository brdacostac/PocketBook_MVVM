namespace TP_MVVM.View.Custom;

public partial class CustomHeaderReturn : ContentView
{
	
    

    public static readonly BindableProperty TitleLastPageTextProperty = BindableProperty.Create(nameof(TitleLastPage), typeof(string), typeof(CustomHeaderReturn), string.Empty);

    public static readonly BindableProperty TitleCurrentPageTextProperty = BindableProperty.Create(nameof(TitleCurrentPage), typeof(string), typeof(CustomHeaderReturn), string.Empty);

    public static readonly BindableProperty IsPlusBtnVisibleProperty = BindableProperty.Create( nameof(IsPlusBtnVisible), typeof(bool), typeof(CustomHeaderReturn), false );

    public static readonly BindableProperty IsArrowBtnVisibleProperty = BindableProperty.Create(nameof(IsArrowBtnVisible), typeof(bool), typeof(CustomHeaderReturn), false);

    public string TitleLastPage
    {
        get => (string)GetValue(TitleLastPageTextProperty);
        set => SetValue(TitleLastPageTextProperty, value);
    }

    public string TitleCurrentPage
    {
        get => (string)GetValue(TitleCurrentPageTextProperty);
        set => SetValue(TitleCurrentPageTextProperty, value);
    }

    public bool IsPlusBtnVisible
    {
        get => (bool)GetValue(IsPlusBtnVisibleProperty);
        set => SetValue(IsPlusBtnVisibleProperty, value);
    }

    public bool IsArrowBtnVisible
    {
        get => (bool)GetValue(IsArrowBtnVisibleProperty);
        set => SetValue(IsArrowBtnVisibleProperty, value);
    }

    public CustomHeaderReturn()
    {
        InitializeComponent();
    }
}