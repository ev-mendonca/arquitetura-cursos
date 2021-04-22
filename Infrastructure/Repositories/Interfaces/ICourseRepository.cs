using Arquitetura_Curso_DIO.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Arquitetura_Curso_DIO.Infrastructure.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        /// <summary>
        /// Método que adiciona um curso ao contexto.
        /// </summary>
        /// <param name="course">Objeto curso que deve ser adicionado</param>
        /// <returns></returns>
        Task AddAsync(Course course);

        /// <summary>
        /// Método que retorna uma lista de cursos conforme filtro informado
        /// </summary>
        /// <param name="predicate">Filtro para condicionar a pesquisa de cursos</param>
        /// <returns></returns>
        Task<IEnumerable<Course>> WhereAsync(Expression<Func<Course,bool>> predicate);
        
        /// <summary>
        /// Método que retorna um curso com base no ID informado. O objeto curso vem apenas com as informações básicas do curso, sem carregar nenhum objeto adicional.
        /// </summary>
        /// <param name="id">Id do curso desejado</param>
        /// <returns></returns>
        Task<Course> FindAsync(int id);

        /// <summary>
        /// Método que retorna um curso conforme filtro informado. 
        /// Caso existam 2 ou mais cursos que respondam a requisição, será retornado o primeiro curso encontrado.
        /// O objeto curso vem carregado com todos objetos adicionais
        /// </summary>
        /// <param name="predicate">Filtro para condicionar a pesquisa do cursos</param>
        /// <returns></returns>
        Task<Course> GetAsync(Expression<Func<Course, bool>> predicate);


        /// <summary>
        /// Método que executa os savechanges do contexto, ao ser chamado, executa todas as alterações pendentes.
        /// </summary>
        /// <returns></returns>
        Task SaveChangesAsync();
    }
}
