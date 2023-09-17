namespace TP_MVVM.View;

public partial class Emprunts : ContentPage
{
	public Emprunts()
	{
		InitializeComponent();

        var items = new List<object>
        {
            new { BookImage="Resources/Images/book1.png", BookName = "La Horde du contrevent", BookAuteur = "Alain Damasio", Status = "Non lu" },
            new { BookImage="Resources/Images/book2.jpg", BookName = "La zone du dehors", BookAuteur = "Alain Damasio", Status = "Terminé" },

        };


        listEmprunts.ItemsSource = items;
    }
}