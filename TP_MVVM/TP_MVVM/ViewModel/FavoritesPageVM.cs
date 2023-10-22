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
    public partial class FavoritesPageVM : ObservableObject
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

        public FavoritesPageVM(ManagerVM managerVM, NavigationVM navigationVM) {
            ManagerVM = managerVM;
            NavigationVM = navigationVM;

        }
    }
}
