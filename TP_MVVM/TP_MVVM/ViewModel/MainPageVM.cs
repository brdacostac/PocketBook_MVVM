using Model;
using MyToolKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Views;
using TP_MVVM.View.Custom;
using System.Windows.Input;
using ViewModelWrapper;

namespace TP_MVVM.ViewModel
{
    public class MainPageVM
    {
        public ManagerVM ManagerVM { get; private set; }
        public NavigationVM NavigationVM { get; private set; }

        public ICommand GetBooksAndNavigateCommand { get; set; }

        public ICommand GetAuthorsAndNavigateCommand { get; set; }

        public ICommand GetFavoritesAndNavigateCommand { get; set; }

        public ICommand NavigateToAddBookCommand { get; set; }

        public ICommand NavigateToDatesCommand { get; set; }

        public ICommand NavigateToEmpruntsCommand { get; set; }


        private void NavigateToEmprunts()
        {
            NavigationVM.NavigateToEmpruntsCommand.Execute(null);
        }
        private void NavigateToDates()
        {
            NavigationVM.NavigateToDatesCommand.Execute(null);
        }

        private void NavigateToAddBook()
        {
            NavigationVM.NavigateToAddBookCommand.Execute(null);
        }

        private void GetBooksAndNavigate()
        {
            ManagerVM.GetBooksCommand.Execute(null);
            NavigationVM.NavigateToBooksCommand.Execute(null);
        }

        private void GetAuthorsAndNavigate()
        {
            ManagerVM.GetAuthorsCommand.Execute(null);
            NavigationVM.NavigateToAuthorsCommand.Execute(null);
        }

        private void GetFavoritesAndNavigate()
        {
            ManagerVM.GetFavoriteBooksCommand.Execute(null);
            NavigationVM.NavigateToFavoritesCommand.Execute(null);
        }



        public MainPageVM(ManagerVM managerVM, NavigationVM navigationVM)
        {
            ManagerVM = managerVM;
            NavigationVM = navigationVM;

            GetBooksAndNavigateCommand = new RelayCommand(GetBooksAndNavigate);
            GetAuthorsAndNavigateCommand = new RelayCommand(GetAuthorsAndNavigate);
            GetFavoritesAndNavigateCommand = new RelayCommand(GetFavoritesAndNavigate);
            NavigateToAddBookCommand = new RelayCommand(NavigateToAddBook);
            NavigateToDatesCommand = new RelayCommand(NavigateToDates);
            NavigateToEmpruntsCommand = new RelayCommand(NavigateToEmprunts);
        }
    }
}
