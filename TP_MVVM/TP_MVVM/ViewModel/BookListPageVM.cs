using MyToolKit;
using System;
using System.Windows.Input;
using ViewModelWrapper;

namespace TP_MVVM.ViewModel
{
	public class BookListPageVM : BaseViewModel
	{
        public ManagerVM ManagerVM { get; private set; }
        public NavigationVM NavigationVM { get; private set; }

        public ICommand LoadBookAndNavigateCommand { get; set; }


        private void LoadBookAndNavigate(BookVM bookVM)
        {
            ManagerVM.GetBookCommand.Execute(bookVM);
            NavigationVM.NavigateToBookDetailCommand.Execute(null);

        }



        public BookListPageVM(ManagerVM managerVM, NavigationVM navigationVM)
        {
            ManagerVM = managerVM;
            NavigationVM = navigationVM;

            LoadBookAndNavigateCommand = new Command<BookVM>(LoadBookAndNavigate);

        }


    }
}

