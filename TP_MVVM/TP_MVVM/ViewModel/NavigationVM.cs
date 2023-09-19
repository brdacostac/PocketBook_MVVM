using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TP_MVVM.View;

namespace TP_MVVM.ViewModel
{
    public class NavigationVM
    {
        public ICommand NavigateToBooksCommand { get; set; }

        public INavigation Navigation => (App.Current as App).MainPage.Navigation;

        public NavigationVM() {
            NavigateToBooksCommand = new Command(async () => await Navigation.PushAsync(new BookDetail()));
        }

    }
}
