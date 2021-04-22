using System.Collections.Generic;

namespace Arquitetura_Curso_DIO.Business.Entities
{
    public class Course
    {
        public int Id { get; }
        public string Title { get; }
        public virtual List<User> Users { get; }
        
        public Course(string title)
        {
            
            Title = title;
        }
    }
}
