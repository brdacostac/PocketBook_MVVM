﻿using System;
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
        public ICommand NavigateToBookDetail { get; set; }
        public ICommand NavigateToEmprunt { get; set; }
        public ICommand NavigateToAuteurs { get; set; }
        public ICommand NavigateToBookDetailCommand { get; set; }
        public IServiceProvider Provider { get; set; }



        public INavigation Navigation => (App.Current as App).MainPage.Navigation;

        public NavigationVM(IServiceProvider provider) {
            Provider = provider;
            NavigateToBooksCommand = new Command(async () => await Navigation.PushAsync(Provider.GetService<MyList>()));
            NavigateToBookDetailCommand = new Command(async () => await Navigation.PushAsync(Provider.GetService<BookDetail>()));
            NavigateToEmprunt = new Command(async () => await Navigation.PushAsync(new Emprunts()));
            NavigateToAuteurs = new Command(async () => await Navigation.PushAsync(new Auteurs()));
        }

    }
}
