using Arquitetura_Curso_DIO.Business.Entities;
using Arquitetura_Curso_DIO.Models.Requests;
using Arquitetura_Curso_DIO.Models.Responses;
using AutoMapper;

namespace Arquitetura_Curso_DIO.Models.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResponse>(MemberList.None);

            CreateMap<CreateUserRequest, User>(MemberList.None);
        }
    }
}
