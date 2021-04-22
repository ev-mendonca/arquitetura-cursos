using Arquitetura_Curso_DIO.Business.Entities;

namespace Arquitetura_Curso_DIO.Infrastructure.Configuration.Interfaces
{
    public interface IAuthenticationService
    {
        string GenerateToken(User user);
    }
}
