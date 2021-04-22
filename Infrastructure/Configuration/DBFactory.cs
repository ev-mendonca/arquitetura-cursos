using Arquitetura_Curso_DIO.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Arquitetura_Curso_DIO.Infrastructure.Configuration
{
    public class DBFactory : IDesignTimeDbContextFactory<ArquiteturaCursoDbContext>
    {
        private readonly IConfiguration _configuration;

        public DBFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ArquiteturaCursoDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ArquiteturaCursoDbContext>();
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("default"));
            ArquiteturaCursoDbContext context = new ArquiteturaCursoDbContext(optionsBuilder.Options);

            return context;
        }
    }
}
