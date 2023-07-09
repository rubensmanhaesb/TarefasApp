using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasApp.Services.Models.Requests;

namespace TarefasApp.UI.Models
{
    /// <summary>
    /// Classe para definir o modelo de dados da página de autenticação
    /// </summary>
    public class AutenticarViewModel
    {
        //Propriedade para acessa o modelo de dados
        public AutenticarRequestModel AutenticarRequestModel { get; set; }

        //construtor
        public AutenticarViewModel()
        {
            this.AutenticarRequestModel = new AutenticarRequestModel();
        }
    }
}
