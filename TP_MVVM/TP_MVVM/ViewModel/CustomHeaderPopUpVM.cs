using MyToolKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModelWrapper;

namespace TP_MVVM.ViewModel
{
    public class CustomHeaderPopUpVM : BaseViewModel
    {
        public ManagerVM ManagerVM { get; set; }
        public NavigationVM NavigationVM { get; set; }


        public ICommand AddBookCommand { get; set; }

        private void AddBook(string isbn)
        {
            ManagerVM.AddBookCommand.Execute(isbn);
            ManagerVM.GetBooksCommand.Execute(null);
            NavigationVM.NavigateToBooksCommand.Execute(null);
        }
        public CustomHeaderPopUpVM(ManagerVM managerVM, NavigationVM navigationVM) 
        {
            ManagerVM = managerVM;
            NavigationVM = navigationVM;

            AddBookCommand = new RelayCommand<string>(AddBook);
        }
    }
}
