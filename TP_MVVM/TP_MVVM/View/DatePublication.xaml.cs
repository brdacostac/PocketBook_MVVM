namespace TP_MVVM.View;

public partial class DatePublication : ContentPage
{
	public DatePublication()
	{
		InitializeComponent();

        var items = new List<object>
        {
            new { YearNumber = "2023", CountBook = 3 },
            new { YearNumber = "2022", CountBook = 2 },
            new { YearNumber = "2021", CountBook = 6 },
            new { YearNumber = "2020", CountBook = 2 },
            new { YearNumber = "2019", CountBook = 6 },
            new { YearNumber = "2018", CountBook = 6 },
            new { YearNumber = "2017", CountBook = 2 },

        };


        listViewPublication.ItemsSource = items;
    }
}