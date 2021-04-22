using Arquitetura_Curso_DIO.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Arquitetura_Curso_DIO.Infrastructure.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Task AddAsync(Course course);
        Task<IEnumerable<Course>> WhereAsync(Expression<Func<Course,bool>> predicate);
        Task<Course> GetAsync(int id);
        Task SaveChangesAsync();
    }
}
