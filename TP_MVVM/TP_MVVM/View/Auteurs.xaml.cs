using TP_MVVM.ViewModel;

namespace TP_MVVM.View;

public partial class Auteurs : ContentPage
{

    public AuteursPageVM AuteursPageVM { get; private set; }

    public Auteurs(AuteursPageVM auteursPageVM)
	{
		InitializeComponent();
        this.AuteursPageVM = auteursPageVM;
        BindingContext = this;

    }
}