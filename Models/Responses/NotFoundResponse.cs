
namespace Arquitetura_Curso_DIO.Models.Responses
{
    public class NotFoundResponse
    {
        public string Error { get; set; }
        
        public NotFoundResponse(string error)
        {
            Error = error;
        }

    }

    
}
