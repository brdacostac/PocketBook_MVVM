using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModelWrapper;

namespace TP_MVVM.ViewModel
{
    public partial class AuteursPageVM : ObservableObject
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
        private void GetBooksByAuthorAndNavigate(AuthorVM author)
        {
            ManagerVM.GetBooksByAuthorCommand.Execute(author);
            NavigationVM.NavigateToBooksCommand.Execute(null);
        }



        public AuteursPageVM(ManagerVM managerVM, NavigationVM navigationVM)
        {
            ManagerVM = managerVM;
            NavigationVM = navigationVM;

        }

    }
}
