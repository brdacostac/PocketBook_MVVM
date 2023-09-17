namespace TP_MVVM.View;

public partial class Auteurs : ContentPage
{
	public Auteurs()
	{
		InitializeComponent();

        var items = new List<object>
        {
            new { BookAuteur = "Alain Damasio", CountBook = 3 },
            new { BookAuteur = "Cixin Liu", CountBook = 2 },
            new { BookAuteur = "Bruno Cunha", CountBook = 6 },
            new { BookAuteur = "Bruno Cunha", CountBook = 2 },
            new { BookAuteur = "Bruno Cunha", CountBook = 6 },
            new { BookAuteur = "Bruno Cunha", CountBook = 6 },
            new { BookAuteur = "Bruno Cunha", CountBook = 2 },
            new { BookAuteur = "Bruno Cunha", CountBook = 6 },
            new { BookAuteur = "Bruno Cunha", CountBook = 6 },
            new { BookAuteur = "Bruno Cunha", CountBook = 2 },
            new { BookAuteur = "Bruno Cunha", CountBook = 6 },
            new { BookAuteur = "Bruno Cunha", CountBook = 6 },
            new { BookAuteur = "Bruno Cunha", CountBook = 2 },
            new { BookAuteur = "Bruno Cunha", CountBook = 6 },

        };


        listView.ItemsSource = items;
    }
}