using System.Windows.Input;
using TP_MVVM.View.Custom;
using TP_MVVM.ViewModel;

namespace TP_MVVM.View
{
    public partial class MainPage : ContentPage
    {

        public MainPageVM MainPageVM { get; private set; }


        public MainPage(MainPageVM MainPageVM)
        {
            InitializeComponent();
            this.MainPageVM = MainPageVM;
            BindingContext = this;
            
        }

       
    }
}