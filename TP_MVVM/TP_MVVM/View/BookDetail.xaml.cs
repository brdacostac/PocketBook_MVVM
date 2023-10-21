using TP_MVVM.ViewModel;

namespace TP_MVVM.View;


public partial class BookDetail : ContentPage
{
    public BookDetailPageVM BookDetailPageVM { get; set; }



    public BookDetail(BookDetailPageVM bookDetailPageVM)
	{
		InitializeComponent();
        BookDetailPageVM = bookDetailPageVM;
        BindingContext = this;

    }
}