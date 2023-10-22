
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
    public partial class CustomHeaderPopUpVM : ObservableObject
    {
        [ObservableProperty]
        public ManagerVM managerVM;

        [ObservableProperty]
        public NavigationVM navigationVM;



        [RelayCommand]
        private void AddBook(string isbn)
        {
            ManagerVM.AddBookCommand.Execute(isbn);
            ManagerVM.GetBooksFromCollectionCommand.Execute(null);
            NavigationVM.NavigateToBooksCommand.Execute(null);
        }
        public CustomHeaderPopUpVM(ManagerVM managerVM, NavigationVM navigationVM) 
        {
            ManagerVM = managerVM;
            NavigationVM = navigationVM;

        }
    }
}
