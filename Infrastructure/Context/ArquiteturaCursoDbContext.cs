using Arquitetura_Curso_DIO.Business.Entities;
using Arquitetura_Curso_DIO.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Arquitetura_Curso_DIO.Infrastructure.Context
{
    public class ArquiteturaCursoDbContext : DbContext
    {
        public ArquiteturaCursoDbContext(DbContextOptions<ArquiteturaCursoDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
