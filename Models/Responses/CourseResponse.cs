using System.Collections.Generic;

namespace Arquitetura_Curso_DIO.Models.Responses
{
    public class CourseResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<UserResponse> Users { get; set; }
    }
}
