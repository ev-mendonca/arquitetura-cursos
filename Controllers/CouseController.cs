using Arquitetura_Curso_DIO.Business.Entities;
using Arquitetura_Curso_DIO.Filters;
using Arquitetura_Curso_DIO.Infrastructure.Repositories.Interfaces;
using Arquitetura_Curso_DIO.Models.Requests;
using Arquitetura_Curso_DIO.Models.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace Arquitetura_Curso_DIO.Controllers
{
    [Route("api/courses")]
    [ApiController]
    [Authorize]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public CourseController(ICourseRepository courseRepository, IConfiguration configuration, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _configuration = configuration;
            _mapper = mapper;
        }

        /// <summary>
        /// Endpoint para criação de uma novo usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description:"Sucesso na criação de um usuário", type: typeof(UserResponse))]
        [SwaggerResponse(statusCode: 400, description: "Parâmetro(s) de entrada inválido(s)", type: typeof(BadRequestResponse))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno ocorreu", type: typeof(InternalServerErrorResponse))]
        [ValidateModelStateFilter]
        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateUserRequest request)
        {
            var course = new Course("Title"); 
            
            //_mapper.Map<User>(request);

            await _courseRepository.AddAsync(course);

            await _courseRepository.SaveChangesAsync();
            
            return Created(course.Id.ToString(), course);// _mapper.Map<UserResponse>(user));
        }
    }
}
