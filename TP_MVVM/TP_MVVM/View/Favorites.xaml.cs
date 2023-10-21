using TP_MVVM.ViewModel;

namespace TP_MVVM.View;

public partial class Favorites : ContentPage
{
    public FavoritesPageVM FavoritesPageVM { get; set; }
    public Favorites(FavoritesPageVM favoritesPageVM)
	{
		InitializeComponent();
        FavoritesPageVM = favoritesPageVM;
        BindingContext = this;
    }
}