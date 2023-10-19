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

        public ICommand GetBooksAndNavigateCommand { get; set; }
        public ICommand LoadBookAndNavigateCommand { get; set; }

        private void GetBooksAndNavigate ()
        {
            ManagerVM.GetBooksCommand.Execute(null);
            NavigationVM.NavigateToBooksCommand.Execute(null);
        }

        private void LoadBookAndNavigate(BookVM bookVM)
        {
            ManagerVM.GetBookCommand.Execute(bookVM);
            NavigationVM.NavigateToBookDetailCommand.Execute(null);

        }



        public BookListPageVM(ManagerVM managerVM, NavigationVM navigationVM)
        {
            ManagerVM = managerVM;
            NavigationVM = navigationVM;

            GetBooksAndNavigateCommand = new Command(GetBooksAndNavigate);
            LoadBookAndNavigateCommand = new Command<BookVM>(LoadBookAndNavigate);

        }


    }
}

