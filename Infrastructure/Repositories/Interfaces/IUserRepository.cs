using Arquitetura_Curso_DIO.Business.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Arquitetura_Curso_DIO.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Método que adiciona um usuário no contexto
        /// </summary>
        /// <param name="user">usuário que será adicionado no contexto</param>
        /// <returns></returns>
        Task AddAsync(User user);

        /// <summary>
        /// Método que retorna uma lista de usuários com base no filtro indicado
        /// </summary>
        /// <param name="predicate">Filtro que condiciona a pesquisa de usuários</param>
        /// <returns></returns>
        Task<User> WhereAsync(Expression<Func<User,bool>> predicate);

        /// <summary>
        /// Método que executa o savechanges do contexto no banco de dados
        /// </summary>
        /// <returns></returns>
        Task SaveChangesAsync();
    }
}
