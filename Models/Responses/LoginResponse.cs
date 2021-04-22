using System.Collections.Generic;

namespace Arquitetura_Curso_DIO.Models.Responses
{
    public class LoginResponse
    {
        public string Token { get; }
        public UserResponse User { get; }
        
        public LoginResponse(string token, UserResponse user)
        {
            Token = token;
            User = user;
        }
    }
        
}
