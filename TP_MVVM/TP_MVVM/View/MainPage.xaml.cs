namespace TP_MVVM.View
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();


            var items = new List<object>
        {
            new { IconPath = "Resources/Images/tray_fill.png", Text = "Tous", CountBook = 45 },
            new { IconPath = "Resources/Images/person_badge_clock_fill.png", Text = "En prêt", CountBook = 1 },
            new { IconPath = "Resources/Images/arrow_forward.png", Text = "À lire plus tard", CountBook = "" },
            new { IconPath = "Resources/Images/eyeglasses.png", Text = "Statut de lecture", CountBook = "" },
            new { IconPath = "Resources/Images/heart_fill.png", Text = "Favoris", CountBook = "" },
            new { IconPath = "Resources/Images/tag_fill.png", Text = "Étiquettes", CountBook = "" }
        };

            var items2 = new List<object>
        {
            new { IconPath = "Resources/Images/person_fill.png", Text = "Auteur" },
            new { IconPath = "Resources/Images/calendar.png", Text = "Date de publication" },
            new { IconPath = "Resources/Images/sparkles.png", Text = "Note" },
        };


            listView.ItemsSource = items;
            listView2.ItemsSource = items2;
        }

    }
}