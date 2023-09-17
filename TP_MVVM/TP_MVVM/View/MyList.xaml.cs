namespace TP_MVVM.View;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_MVVM.View;

public partial class MyList : ContentPage
{
	public MyList()
	{
		InitializeComponent();


        var items = new List<object>
        {
            new { BookImage="Resources/Images/book1.png", BookName = "La Horde du contrevent", BookAuteur = "Alain Damasio", Status = "Non lu" },
            new { BookImage="Resources/Images/book2.jpg", BookName = "La zone du dehors", BookAuteur = "Alain Damasio", Status = "Terminé" },

        };


        listView.ItemsSource = items;

        listView.ItemTapped += OnItemTapped;
    }

    private async void OnItemTapped(object sender, ItemTappedEventArgs e)
    {
            await Navigation.PushAsync(new BookDetail());

    }
}