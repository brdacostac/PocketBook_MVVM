using CommunityToolkit.Maui.Views;
using System.Windows.Input;
using TP_MVVM.ViewModel;


namespace TP_MVVM.View.Custom;

public partial class CustomMenuPopUp : ContentPage
{

	public CustomHeaderPopUpVM CustomHeaderPopUpVM { get; set; }
    public CustomMenuPopUp(CustomHeaderPopUpVM customHeaderPopUpVM)
	{
        InitializeComponent();
        CustomHeaderPopUpVM = customHeaderPopUpVM;
        BindingContext = this;
	}
}