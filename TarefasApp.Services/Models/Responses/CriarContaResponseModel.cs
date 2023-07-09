using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarefasApp.Services.Models.Responses
{
    /// <summary>
    /// Modelo de dadoso para a resposta de criação de conta de Usuários
    /// </summary>
    public class CriarContaResponseModel
    {
        public Guid? Id { get; set; }
        public string? Nome{ get; set; }
        public string? Email { get; set; }

    }
}
