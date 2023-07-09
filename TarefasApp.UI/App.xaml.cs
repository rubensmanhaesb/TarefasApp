namespace TarefasApp.UI;

public partial class App : Application
{
	/// <summary>
	/// Construtor que inicializa o componente inicial do aplicativo
	/// </summary>
	public App()
	{
		//Inicializar o componente (abrir)
		InitializeComponent();

		//Definindo a página inicial do projeto
		MainPage = new AppShell();
	}
}
