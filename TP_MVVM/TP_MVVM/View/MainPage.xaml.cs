﻿using CommunityToolkit.Maui.Views;
using System.Windows.Input;
using TP_MVVM.View.Custom;
using TP_MVVM.ViewModel;

namespace TP_MVVM.View
{
    public partial class MainPage : ContentPage
    {
       
        public NavigationVM Navigater {get; private set;}

        public BookListPageVM BookListPageVM { get; private set; }


        public MainPage(BookListPageVM BookListPageVM)
        {
            InitializeComponent();
            this.BookListPageVM = BookListPageVM;
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