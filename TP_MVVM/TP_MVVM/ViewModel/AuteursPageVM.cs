using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModelWrapper;
using MyToolKit;

namespace TP_MVVM.ViewModel
{
    public class AuteursPageVM
    {
        public ManagerVM ManagerVM { get; private set; }

        public NavigationVM NavigationVM { get; private set; }

        public ICommand GetBooksByAuthorAndNavigateCommand { get; set; }

        private void GetBooksByAuthorAndNavigate(AuthorVM author)
        {
            ManagerVM.GetBooksByAuthorCommand.Execute(author);
            NavigationVM.NavigateToBooksCommand.Execute(null);
        }


        public AuteursPageVM(ManagerVM managerVM, NavigationVM navigationVM)
        {
            ManagerVM = managerVM;
            NavigationVM = navigationVM;

            GetBooksByAuthorAndNavigateCommand = new Command<AuthorVM>(GetBooksByAuthorAndNavigate);

        }

    }
}
