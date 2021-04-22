using Arquitetura_Curso_DIO.Business.Entities;
using Arquitetura_Curso_DIO.Infrastructure.Context;
using Arquitetura_Curso_DIO.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Arquitetura_Curso_DIO.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ArquiteturaCursoDbContext _context;

        public UserRepository(ArquiteturaCursoDbContext context)
        {
            _context = context;
        }
        
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }
        
        public async Task<User> WhereAsync(Expression<Func<User, bool>> predicate)
        {
            return await _context.Users.Include(x=>x.Courses).FirstOrDefaultAsync(predicate);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
