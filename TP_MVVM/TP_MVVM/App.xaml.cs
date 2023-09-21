using System.Security.Cryptography.X509Certificates;
using TP_MVVM.ViewModel;

namespace TP_MVVM
{
    public partial class App : Application
    {
       // public NavigationVM Navigater => (App.Current as App).Navigater;
        public App()
        {

            
            InitializeComponent();

            MainPage = new AppShell();
          //  BindingContext = this;
        }
    }
}