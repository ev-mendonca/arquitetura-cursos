using System.ComponentModel.DataAnnotations;

namespace Arquitetura_Curso_DIO.Models.Requests
{
    public class CreateUserRequest
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(maximumLength:150, MinimumLength = 10, ErrorMessage = "Nome deve conter entre 10 e 150 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(maximumLength:20, MinimumLength = 5, ErrorMessage = "Senha deve conter entre 5 e 20 caracteres")]
        public string Password { get; set; }
    }
}
