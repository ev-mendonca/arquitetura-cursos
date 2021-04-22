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
using System.Security.Claims;
using System.Threading.Tasks;

namespace Arquitetura_Curso_DIO.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, ICourseRepository courseRepository,  IConfiguration configuration, IMapper mapper)
        {
            _userRepository = userRepository;
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
            
            
            //var migrationsPending = await context.Database.GetPendingMigrationsAsync();

            //if(migrationsPending.Count() > 0 )
            //{
            //    await context.Database.MigrateAsync();
            //}

            var user = _mapper.Map<User>(request);

            await _userRepository.AddAsync(user);

            await _userRepository.SaveChangesAsync();
            
            return Created(user.Id.ToString(), _mapper.Map<UserResponse>(user));
        }


        /// <summary>
        /// Endpoint para gerar uma matrícula do usuário logado em um curso
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso na criação de um usuário", type: typeof(UserResponse))]
        [SwaggerResponse(statusCode: 400, description: "Parâmetro(s) de entrada inválido(s)", type: typeof(BadRequestResponse))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno ocorreu", type: typeof(InternalServerErrorResponse))]
        [ValidateModelStateFilter]
        [HttpPost]
        [Route("me/courses")]
        public async Task<IActionResult> PostCourseAsync([FromBody]int courseId)
        {
            int loggedUserId = int.Parse(User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value);

            var user = await _userRepository.WhereAsync(x => x.Id == loggedUserId);

            var course = await _courseRepository.GetAsync(courseId);

            user.Courses.Add(course);
            
            await _userRepository.SaveChangesAsync();

            return Ok();
        }
    }
}
