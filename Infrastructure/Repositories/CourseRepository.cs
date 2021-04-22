using Arquitetura_Curso_DIO.Business.Entities;
using Arquitetura_Curso_DIO.Infrastructure.Context;
using Arquitetura_Curso_DIO.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Arquitetura_Curso_DIO.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ArquiteturaCursoDbContext _context;

        public CourseRepository(ArquiteturaCursoDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
        }

        public async Task<Course> GetAsync(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public async Task<IEnumerable<Course>> WhereAsync(Expression<Func<Course, bool>> predicate)
        {
            return await _context.Courses.Where(predicate).ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        
    }
}
