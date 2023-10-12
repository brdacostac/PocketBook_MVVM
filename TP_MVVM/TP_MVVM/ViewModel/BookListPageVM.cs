using System;
using System.Windows.Input;
using ViewModelWrapper;

namespace TP_MVVM.ViewModel
{
	public class BookListPageVM
	{
        public ManagerVM ManagerVM { get; private set; }
        public NavigationVM NavigationVM { get; private set; }



        public BookListPageVM(ManagerVM managerVM, NavigationVM navigationVM)
        {
            ManagerVM = managerVM;
            NavigationVM = navigationVM;
       	}


    }
}

