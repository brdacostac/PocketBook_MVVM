using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModelWrapper;

namespace TP_MVVM.ViewModel
{
    public partial class BookDetailPageVM : ObservableObject
    {

        [ObservableProperty]
        public ManagerVM managerVM;


        [ObservableProperty]
        public NavigationVM navigationVM;

        private string favoriteOptionText ;


        [RelayCommand]
        private void NavigateToBack()
        {
            NavigationVM.NavigateToBackCommand.Execute(null);
        }

        public string FavoriteButtonText
        {
            get
            {
                ManagerVM.GetFavoriteBooksCommand.Execute(null);

                if (ManagerVM.FavoriteBooks.Any(favoriteBook => favoriteBook.Title == ManagerVM.CurrentBook.Title))
                    return favoriteOptionText = "Supprimer des favoris";

                return favoriteOptionText = "Ajouter aux favoris";
            }
            set
            {
                    SetProperty(ref favoriteOptionText, value);
            }
        }

        [RelayCommand]
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

        [RelayCommand]
        private void RemoveBookAndNavigate(BookVM bookVM)
        {
            ManagerVM.RemoveBookCommand.Execute(bookVM);
            ManagerVM.GetBooksFromCollectionCommand.Execute(null);
            NavigationVM.NavigateToBackCommand.Execute(null);
            
        }


        public BookDetailPageVM(ManagerVM managerVM, NavigationVM navigationVM)
        {

            ManagerVM = managerVM;
            NavigationVM = navigationVM;

        }
    }
}
