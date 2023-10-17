namespace TP_MVVM.View;
using Microsoft.Maui.Controls;
using System.Linq;
using ViewModel;
using ViewModelWrapper;

public partial class MyList : ContentPage
{


    public BookListPageVM BookListPageVM { get; set; }


    
    public MyList(BookListPageVM bookListPageVM)
	{
        InitializeComponent();
        BookListPageVM = bookListPageVM;
        BindingContext = this;

    }

}