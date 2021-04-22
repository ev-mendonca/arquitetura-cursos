using Arquitetura_Curso_DIO.Business.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Arquitetura_Curso_DIO.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> WhereAsync(Expression<Func<User,bool>> predicate);

        Task SaveChangesAsync();
    }
}
