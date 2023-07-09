using TarefasApp.UI.Views;

namespace TarefasApp.UI;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}
	/// <summary>
	/// Método para o evento Tapped
	/// </summary> 
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private async void EsqueciMinhaSenhaTapped(object sender, EventArgs e)
	{
		//redirecionando
		await Navigation.PushAsync(new PasswordRecover());
	}
    /// <summary>
    /// Método para o evento Tapped
    /// </summary> 
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void CriarContaTapped(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new Register());
    }
}

