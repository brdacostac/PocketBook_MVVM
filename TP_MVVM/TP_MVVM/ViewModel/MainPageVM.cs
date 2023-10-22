using Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModelWrapper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TP_MVVM.ViewModel
{
    public partial class MainPageVM : ObservableObject
    {
        [ObservableProperty]
        public ManagerVM managerVM;

        [ObservableProperty]
        public NavigationVM navigationVM;


        [RelayCommand]
        private void NavigateToEmprunts()
        {
            NavigationVM.NavigateToEmpruntsCommand.Execute(null);
        }

        [RelayCommand]
        private void NavigateToDates()
        {
            NavigationVM.NavigateToDatesCommand.Execute(null);
        }

        [RelayCommand]

        private void NavigateToAddBook()
        {
            NavigationVM.NavigateToAddBookCommand.Execute(null);
        }

        [RelayCommand]
        private void GetBooksAndNavigate()
        {
            ManagerVM.GetBooksFromCollectionCommand.Execute(null);
            NavigationVM.NavigateToBooksCommand.Execute(null);
        }

        [RelayCommand]

        private void GetAuthorsAndNavigate()
        {
            ManagerVM.GetAllAuthorsCommand.Execute(null);
            NavigationVM.NavigateToAuthorsCommand.Execute(null);
        }

        [RelayCommand]
        private void GetFavoritesAndNavigate()
        {
            ManagerVM.GetFavoriteBooksCommand.Execute(null);
            NavigationVM.NavigateToFavoritesCommand.Execute(null);
        }



        public MainPageVM(ManagerVM managerVM, NavigationVM navigationVM)
        {
            ManagerVM = managerVM;
            NavigationVM = navigationVM;

        }
    }
}
