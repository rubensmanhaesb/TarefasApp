using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasApp.Services.Models.Responses;

namespace TarefasApp.UI.Behaviors
{
    /// <summary>
    /// Classe para implementar os comportamentos da página
    /// </summary>
    public class DashboardBehavior :Behavior<ContentPage>
    {
        private AutenticarResponseModel _autenticarResponseModel;
        private Label _nomeUsuario;
        private Label _emailUsuario;
        private Button _btnLogout;


        /// <summary>
        /// método para capturar os elementos da página
        /// e adicionar comportamentos e eventos
        /// </summary>
        /// <param name="bindable"></param>
        protected override async void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);

            #region Captura as informações do usuário autenticado

            var auth = await SecureStorage.GetAsync("auth_user");
            _autenticarResponseModel = JsonConvert.DeserializeObject<AutenticarResponseModel>(auth);

            #endregion

            #region Capturar os elementos da página
                _nomeUsuario = bindable.FindByName<Label>("nomeUsuario");
                _emailUsuario = bindable.FindByName<Label>("emailUsuario");
                _btnLogout  = bindable.FindByName<Button>("btnLogout");
            #endregion

            #region Criando os eventos
                _nomeUsuario.Text = _autenticarResponseModel.Nome;
                _emailUsuario.Text = _autenticarResponseModel.Email;
                _btnLogout.Clicked += OnLogoutClicked;
            #endregion 
        }

        /// <summary>
        /// Função de processar o evento clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnLogoutClicked (object sender, EventArgs e)
        {
            var isAccepted = await App.Current.MainPage.DisplayAlert("Sair da conta?", $"Olá {_autenticarResponseModel.Nome}, deseja realmente sair da sua conta?",
                "Sim, sair da conta!", "Cancelar");

            if (isAccepted)
            {
                //apaga os dados gravados na Secure Storage
                SecureStorage.Default.Remove("auth_user");
                //redirecionar de volta para a MainPage
                await Shell.Current.GoToAsync("///MainPage");
            }
        }
    }
}
