namespace TP_MVVM.View.Custom;
using CommunityToolkit.Maui.Views;

public partial class CustomHeader : ContentView
{
	public CustomHeader()
	{
		InitializeComponent();
	}

    public event EventHandler PopupRequested;

    private void PopUp(object sender, EventArgs e)
    {
        this.PopupRequested?.Invoke(this, EventArgs.Empty);
    }
}