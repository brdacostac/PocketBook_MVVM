namespace TP_MVVM.View;
using Microsoft.Maui.Controls;
using System.Linq;
using ViewModel;
using ViewModelWrapper;

public partial class MyList : ContentPage
{


    public BookListPageVM BookListPageVM { get; set; }

    void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is BookVM)
        {
            var result = new BookDetailPageVM(e.CurrentSelection.FirstOrDefault() as BookVM);
            //App.Current.MainPage.Navigation.PushAsync(new BookDetail(result));
        }
    }

    
    public MyList()
	{
        InitializeComponent();
    }

}