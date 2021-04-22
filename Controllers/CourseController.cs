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
using System;
using System.Threading.Tasks;

namespace Arquitetura_Curso_DIO.Controllers
{
    [Route("api/courses")]
    [ApiController]
    [Authorize]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseController(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Endpoint para criação de uma novo curso
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description:"Sucesso na criação de um curso", type: typeof(CourseResponse))]
        [SwaggerResponse(statusCode: 400, description: "Parâmetro(s) de entrada inválido(s)", type: typeof(BadRequestResponse))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno ocorreu", type: typeof(InternalServerErrorResponse))]
        [ValidateModelStateFilter]
        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateCourseRequest request)
        {
            try
            {
                var course = _mapper.Map<Course>(request);

                await _courseRepository.AddAsync(course);

                await _courseRepository.SaveChangesAsync();

                return Created(course.Id.ToString(), _mapper.Map<CourseResponse>(course));
            }
            catch(Exception ex)
            {
                return StatusCode(500, InternalServerErrorResponse.InternalServerErrofactory(ex));
            }
        }

        /// <summary>
        /// Endpoint para carregar um curso
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Curso carregado e retornado", type: typeof(CourseResponse))]
        [SwaggerResponse(statusCode: 404, description: "Curso não encontrado.", type: typeof(NotFoundResponse))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno ocorreu", type: typeof(InternalServerErrorResponse))]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var course = await _courseRepository.GetAsync(x=>x.Id == id);
                
                if (course == null)
                    return NotFound(new NotFoundResponse("Curso não encotrado. Identificador inválido"));

                return Ok(_mapper.Map<CourseResponse>(course));
            }
            catch(Exception ex)
            {
                return StatusCode(500, InternalServerErrorResponse.InternalServerErrofactory(ex));
            }
        }

    }
}
