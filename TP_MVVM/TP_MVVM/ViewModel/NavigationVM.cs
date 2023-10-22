using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TP_MVVM.View;
using TP_MVVM.View.Custom;

namespace TP_MVVM.ViewModel
{
    public class NavigationVM
    {
        public ICommand NavigateToBooksCommand { get; set; }
        public ICommand NavigateToAuthorsCommand { get; set; }
        public ICommand NavigateToBookDetailCommand { get; set; }
        public ICommand NavigateToFavoritesCommand { get; set; }
        public ICommand NavigateToDatesCommand { get; set; }
        public ICommand NavigateToBackCommand { get; set; }
        public ICommand NavigateToAddBookCommand { get; set; }
        public ICommand NavigateToEmpruntsCommand { get; set; }


        public IServiceProvider Provider { get; set; }



        public INavigation Navigation => (App.Current as App).MainPage.Navigation;

        public NavigationVM(IServiceProvider provider) {
            Provider = provider;
            NavigateToBooksCommand = new Command(async () => await Navigation.PushAsync(Provider.GetService<MyList>()));
            NavigateToBookDetailCommand = new Command(async () => await Navigation.PushAsync(Provider.GetService<BookDetail>()));
            NavigateToAuthorsCommand = new Command(async () => await Navigation.PushAsync(Provider.GetService<Auteurs>()));
            NavigateToFavoritesCommand = new Command(async () => await Navigation.PushAsync(Provider.GetService<Favorites>()));
            NavigateToDatesCommand = new Command(async () => await Navigation.PushAsync(Provider.GetService<DatePublication>()));
            NavigateToEmpruntsCommand = new Command(async () => await Navigation.PushAsync(Provider.GetService<Emprunts>()));
            NavigateToAddBookCommand = new Command(async () => await Navigation.PushAsync(Provider.GetService<CustomMenuPopUp>()));

            NavigateToBackCommand = new Command(async () => await Navigation.PopAsync());
        }

    }
}
