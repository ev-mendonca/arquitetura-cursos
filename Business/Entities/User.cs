using System.Collections.Generic;

namespace Arquitetura_Curso_DIO.Business.Entities
{
    public class User
    {
        public int Id { get; }
        public string Name { get; }
        public string Email { get; }
        public string Password { get; }
        public virtual List<Course> Courses { get; }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
