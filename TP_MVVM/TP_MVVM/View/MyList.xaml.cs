namespace TP_MVVM.View;

public partial class MyList : ContentPage
{
	public MyList()
	{
		InitializeComponent();

        var items = new List<object>
        {
            new { BookName = "La Horde du contrevent", BookAuteur = "Alain Damasio", Status = "Non lu" },

        };


        listView.ItemsSource = items;
    }
}