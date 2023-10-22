using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyToolKit;
using System.Windows.Input;
using ViewModelWrapper;

namespace TP_MVVM.ViewModel
{
    public class FavoritesPageVM
    {
        public ManagerVM ManagerVM { get; private set; }

        public NavigationVM NavigationVM { get; private set; }

        public ICommand LoadBookAndNavigateCommand { get; set; }

        public ICommand NavigateToBackCommand { get; set; }

        private void NavigateToBack()
        {
            NavigationVM.NavigateToBackCommand.Execute(null);
        }


        private void LoadBookAndNavigate(BookVM bookVM)
        {
            ManagerVM.GetBookCommand.Execute(bookVM);
            NavigationVM.NavigateToBookDetailCommand.Execute(null);

        }

        public FavoritesPageVM(ManagerVM managerVM, NavigationVM navigationVM) {
            ManagerVM = managerVM;
            NavigationVM = navigationVM;

            LoadBookAndNavigateCommand = new RelayCommand<BookVM>(LoadBookAndNavigate);
            NavigateToBackCommand = new RelayCommand(NavigateToBack);
        }
    }
}
