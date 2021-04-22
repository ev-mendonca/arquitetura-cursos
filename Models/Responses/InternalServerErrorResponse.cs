using System;

namespace Arquitetura_Curso_DIO.Models.Responses
{
    public class InternalServerErrorResponse
    {
        public string Message { get; }

        private InternalServerErrorResponse(string message)
        {
            Message = message;
        }

        public static InternalServerErrorResponse InternalServerErrofactory(Exception ex)
        {
            return new InternalServerErrorResponse(ex.Message);
        }
    }
}
