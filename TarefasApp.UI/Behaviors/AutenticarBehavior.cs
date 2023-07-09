using Newtonsoft.Json;
using Syncfusion.Maui.DataForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasApp.Services.Helpers;
using TarefasApp.Services.Models.Requests;
using TarefasApp.Services.Models.Responses;

namespace TarefasApp.UI.Behaviors
{
    /// <summary>
    /// Classes para definir os comportamentos da página de autenticação
    /// </summary>
    public class AutenticarBehavior:Behavior<ContentPage>
    {
        //atributos
        private Button _btnAcesso;
        private SfDataForm _formAutenticar;


        /// <summary>
        /// método para implementar os eventos da página
        /// </summary>
        /// <param name="bindable"></param>
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);

            //capturar  botão da página
            this._btnAcesso = bindable.FindByName<Button>("btnAcesso");
            //criando o evento para o botão
            this._btnAcesso.Clicked += OnButtonClicked;

            //capturar o Formulário

            this._formAutenticar = bindable.FindByName<SfDataForm>("formAutenticar");
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            //verifica se os campos estão corretos
            if (this._formAutenticar.Validate())
            {
                try
                {
                    //captura os campos do formulário
                    var model = (AutenticarRequestModel)this._formAutenticar.DataObject;

                    //enviando a requisição para a API..
                    var serviceHelper = new ServicesHelper();
                    var result = await serviceHelper.Post<AutenticarRequestModel, AutenticarResponseModel>
                        ("autenticar", model);                

                    await App.Current.MainPage.DisplayAlert($"Olá, {result.Nome}", "Olá eu sou um botão", "OK");

                    //await App.Current.MainPage.DisplayAlert("Dados obtidos", JsonConvert.SerializeObject(result), "Ok");
                    await SecureStorage.Default.SetAsync("auth_user", JsonConvert.SerializeObject(result));
                    //Navegação para a página Dashboard
                    await Shell.Current.GoToAsync("///Dashboard");
            
                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Aviso", ex.Message, "OK");
                }

            }
            else 
            {
                await App.Current.MainPage.DisplayAlert("Avso!", "Erro no preenchimento do formulário", "Ok");
            }

        }
    }
}
