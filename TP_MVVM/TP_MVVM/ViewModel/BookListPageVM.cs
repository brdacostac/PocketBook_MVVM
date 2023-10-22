using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Windows.Input;
using ViewModelWrapper;

namespace TP_MVVM.ViewModel
{
	public partial class BookListPageVM : ObservableObject
	{

        [ObservableProperty]
        public ManagerVM managerVM;

        [ObservableProperty]
        public NavigationVM navigationVM;


        [RelayCommand]
        private void NavigateToBack()
        {
            NavigationVM.NavigateToBackCommand.Execute(null);
        }

        [RelayCommand]
        private void LoadBookAndNavigate(BookVM bookVM)
        {
            ManagerVM.GetBookByIdCommand.Execute(bookVM);
            NavigationVM.NavigateToBookDetailCommand.Execute(null);

        }



        public BookListPageVM(ManagerVM managerVM, NavigationVM navigationVM)
        {
            ManagerVM = managerVM;
            NavigationVM = navigationVM;

        }


    }
}

