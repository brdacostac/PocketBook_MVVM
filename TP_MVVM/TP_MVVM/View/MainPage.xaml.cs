using CommunityToolkit.Maui.Views;
using System.Windows.Input;
using TP_MVVM.View.Custom;
using TP_MVVM.ViewModel;

namespace TP_MVVM.View
{
    public partial class MainPage : ContentPage
    {
       
        public NavigationVM Navigater {get; private set;}

        public BookListPageVM GetBookAndNavigate { get; private set; }


        public MainPage(BookListPageVM GetBookAndNavigate)
        {
            InitializeComponent();
            this.GetBookAndNavigate = GetBookAndNavigate;
            BindingContext = this;
            
        }

        private void CallPopUp(object sender, EventArgs e)
        {
            var popup = new CustomMenuPopUp();
            this.ShowPopup(popup);
        }

       

        private void CustomHeader_PopupRequested(object sender, EventArgs e)
        {

        }
    }
}