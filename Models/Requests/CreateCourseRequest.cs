using System.ComponentModel.DataAnnotations;

namespace Arquitetura_Curso_DIO.Models.Requests
{
    public class CreateCourseRequest
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(maximumLength:150, MinimumLength = 10, ErrorMessage = "Título deve conter entre 10 e 150 caracteres")]
        public string Title { get; set; }
    }
}
