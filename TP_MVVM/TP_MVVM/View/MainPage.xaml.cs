using CommunityToolkit.Maui.Views;
using TP_MVVM.View.Custom;
using TP_MVVM.ViewModel;

namespace TP_MVVM.View
{
    public partial class MainPage : ContentPage
    {
       
        public NavigationVM Navigater {get; private set;}

        public MainPage(NavigationVM Navigater)
        {
            InitializeComponent();

            BindingContext = this;

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


            listView.ItemTapped += ListView_ItemTapped;
        }

        private void CallPopUp(object sender, EventArgs e)
        {
            var popup = new CustomMenuPopUp();
            this.ShowPopup(popup);
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                var selectedItem = e.Item as dynamic;

                if (selectedItem.Text == "En prêt")
                {
                    await Navigation.PushAsync(new Emprunts());
                }
            }

            ((ListView)sender).SelectedItem = null;
        }

        private void CustomHeader_PopupRequested(object sender, EventArgs e)
        {

        }
    }
}