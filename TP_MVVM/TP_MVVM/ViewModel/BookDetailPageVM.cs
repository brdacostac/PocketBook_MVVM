using CommunityToolkit.Maui.Alerts;
using Model;
using MyToolKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModelWrapper;

namespace TP_MVVM.ViewModel
{
    public class BookDetailPageVM : BaseViewModel
    {
        public BookVM Book { get; private set; }
        public ManagerVM ManagerVM { get; private set; }

        public ICommand AddRemoveFavoritesCommand { get; private set; }

        public BookDetailPageVM(BookVM bookVM , ManagerVM managerVM)
        {
            Book = bookVM;
            ManagerVM = managerVM;

            AddRemoveFavoritesCommand = new RelayCommand<BookVM>((bookVM) => AddRemoveFavorites(bookVM));
        }

        private async Task AddRemoveFavorites(BookVM bookVM)
        {
            ManagerVM.CheckBookIsFavoriteCommand.Execute(bookVM);
            if (ManagerVM.IsFavorite == false)
            {
                ManagerVM.AddToFavoritesCommand.Execute(bookVM);
                AddFavorisButtonText = "Supprimer des favoris";
                OnPropertyChanged(nameof(AddFavorisButtonText));

                var toast = Toast.Make("Livre ajouté aux favoris !", CommunityToolkit.Maui.Core.ToastDuration.Short);
                await toast.Show();

                ManagerVM.GetFavoriteBooksCommand.Execute(null);
                Navigator.NavigationCommand.Execute("/favoris");
            }
            else
            {
                ManagerVM.RemoveFromFavoritesCommand.Execute(bookVM);
                AddFavorisButtonText = "Ajouter aux favoris";
                OnPropertyChanged(nameof(AddFavorisButtonText));

                var toast = Toast.Make("Livre supprimé des favoris !", CommunityToolkit.Maui.Core.ToastDuration.Short);
                await toast.Show();

                ManagerVM.GetFavoriteBooksCommand.Execute(null);
                Navigator.NavigationCommand.Execute("/favoris");
            }
        }
    }
}
