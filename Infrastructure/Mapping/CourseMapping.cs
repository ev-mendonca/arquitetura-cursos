using Arquitetura_Curso_DIO.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arquitetura_Curso_DIO.Infrastructure.Mapping
{
    public class CourseMapping : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("course");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.Title).HasColumnName("title").HasMaxLength(255);

            builder.HasMany(x => x.Users).WithMany(x => x.Courses);
        }
    }
}
