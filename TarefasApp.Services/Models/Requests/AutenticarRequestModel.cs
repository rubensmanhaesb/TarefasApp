using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarefasApp.Services.Models.Requests
{
    /// <summary>
    /// Modelo de dados para a requisição de autenticação de usuários
    /// </summary>
    public class AutenticarRequestModel
    {
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Entre com o seu email:", Prompt = "Ex: joaodasilva@gmail.com")]
        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe seu email de acesso.")]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Entre com a sua senha:")]
        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo 8 caracteres.")]
        [Required(ErrorMessage = "Por favor, informe sua senha de acesso.")]
        public string? Senha { get; set; }
    }
}
