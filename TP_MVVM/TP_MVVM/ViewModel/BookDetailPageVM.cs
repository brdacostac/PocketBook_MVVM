using CommunityToolkit.Maui.Alerts;
using Model;
using MyToolKit;
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
    public class BookDetailPageVM : BaseViewModel
    {
        public ManagerVM ManagerVM { get; private set; }

        public NavigationVM NavigationVM { get; private set; }

        private string favoriteOptionText ;

        public ICommand AddRemoveFavoritesCommand { get; private set; }

        public ICommand  RemoveBookCommand { get; private set; }

        public ICommand NavigateToBackCommand { get; set; }

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

        private void RemoveBookAndNavigate(BookVM bookVM)
        {
            ManagerVM.RemoveBookCommand.Execute(bookVM);
            ManagerVM.GetBooksCommand.Execute(null);
            NavigationVM.NavigateToBackCommand.Execute(null);
            
        }

        public BookDetailPageVM(ManagerVM managerVM, NavigationVM navigationVM)
        {

            ManagerVM = managerVM;
            NavigationVM = navigationVM;

            AddRemoveFavoritesCommand = new RelayCommand<BookVM>((bookVM) => AddRemoveFavoritesAndNavigate(bookVM));
            RemoveBookCommand = new RelayCommand<BookVM>((bookVM) => RemoveBookAndNavigate(bookVM));
            NavigateToBackCommand = new RelayCommand(NavigateToBack);
        }
    }
}
