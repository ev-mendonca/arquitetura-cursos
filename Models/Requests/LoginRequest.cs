using System.ComponentModel.DataAnnotations;

namespace Arquitetura_Curso_DIO.Models.Requests
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Password { get; set; }

        
    }
}
