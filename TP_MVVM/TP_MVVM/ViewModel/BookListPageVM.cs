using System;
using System.Windows.Input;
using ViewModelWrapper;

namespace TP_MVVM.ViewModel
{
	public class BookListPageVM
	{
        public ICommand GetAllBooks { get; set; }

        // public BookListPageVM(ManagerVM managerVM, NavigationVM navigationVM)
        //	{
        //		GetAllBooks = managerVM.GetBooksCommand;
        //	}

       
        public BookListPageVM(ManagerVM managerVM)
        {
        	GetAllBooks = managerVM.GetBooksCommand;
       	}


    }
}

