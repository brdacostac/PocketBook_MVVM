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
        public ManagerVM ManagerVM { get; private set; }

        public NavigationVM NavigationVM { get; private set; }

        private string favoriteOptionText;

        public ICommand AddRemoveFavoritesCommand { get; private set; }

        public string FavoriteButtonText
        {
            get
            {
                ManagerVM.GetFavoriteBooksCommand.Execute(null);
                if (ManagerVM.FavoriteBooks.Any(favoriteBook => favoriteBook.Id == ManagerVM.CurrentBook.Id))
                    return favoriteOptionText = "Supprimer des favoris";

                return favoriteOptionText = "Ajouter aux favoris";
            }
            set
            {
                if (favoriteOptionText != value)
                {
                    favoriteOptionText = value;
                    OnPropertyChanged(nameof(FavoriteButtonText));
                }
                    
            }
        }


        private void AddRemoveFavoritesAndNavigate(BookVM bookVM)
        {
            ManagerVM.CheckIsFavoriteCommand.Execute(bookVM);
            if (ManagerVM.IsFavorite == false)
            {
                ManagerVM.AddFavoritesCommand.Execute(bookVM);
                FavoriteButtonText = "Supprimer des favoris";


                ManagerVM.GetFavoriteBooksCommand.Execute(null);
                NavigationVM.NavigateToFavoritesCommand.Execute(null);
            }
            else
            {
                ManagerVM.RemoveFavoritesCommand.Execute(bookVM);
                FavoriteButtonText = "Ajouter aux favoris";

                ManagerVM.GetFavoriteBooksCommand.Execute(null);
                NavigationVM.NavigateToFavoritesCommand.Execute(null);
            }
        }
        public BookDetailPageVM(ManagerVM managerVM, NavigationVM navigationVM)
        {

            ManagerVM = managerVM;
            NavigationVM = navigationVM;

            AddRemoveFavoritesCommand = new RelayCommand<BookVM>((bookVM) => AddRemoveFavoritesAndNavigate(bookVM));
        }
    }
}
