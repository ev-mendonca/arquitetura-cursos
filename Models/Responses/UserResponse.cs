namespace Arquitetura_Curso_DIO.Models.Responses
{
    public class UserResponse
    {
        public int Id { get; }
        public string Name { get; }
        public string Email { get; }

        public UserResponse(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        
    }
}
