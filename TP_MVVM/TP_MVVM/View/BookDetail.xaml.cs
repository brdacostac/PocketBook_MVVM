using TP_MVVM.ViewModel;

namespace TP_MVVM.View;


public partial class BookDetail : ContentPage
{



	public BookDetail()
	{
		InitializeComponent();
		BindingContext = this;


		string BookImage = "Resources/Images/book1.png";
		string BookName = "La horde du contrevent";

		bookImage.Source = BookImage;
		bookName.Text = BookName;


    }
}