using Arquitetura_Curso_DIO.Filters;
using Arquitetura_Curso_DIO.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System;
using System.IdentityModel.Tokens.Jwt;
using Arquitetura_Curso_DIO.Models.Responses;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;
using Arquitetura_Curso_DIO.Infrastructure.Repositories.Interfaces;
using Arquitetura_Curso_DIO.Infrastructure.Configuration.Interfaces;
using System.Threading.Tasks;

namespace Arquitetura_Curso_DIO.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public AccountController(IUserRepository userRepository, IAuthenticationService authenticationService, IMapper mapper)
        {
            _userRepository = userRepository;
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        /// <summary>
        /// Endpoint para fazer login de um usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Login feito com sucesso", type: typeof(LoginResponse))]
        [SwaggerResponse(statusCode: 400, description: "Parâmetro(s) de entrada inválido(s)", type: typeof(BadRequestResponse))]
        [SwaggerResponse(statusCode: 404, description: "Usuário não encontrado. Email ou senha icorreto.", type: typeof(NotFoundResponse))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno ocorreu", type: typeof(InternalServerErrorResponse))]
        [ValidateModelStateFilter]
        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> PostSignin(LoginRequest request)
        {
            try
            {
                var user = await _userRepository.WhereAsync(x => x.Email == request.Email && x.Password == request.Password);

                if (user != null)
                {
                    string token = _authenticationService.GenerateToken(user);
                    return Ok(new LoginResponse(token, _mapper.Map<UserResponse>(user)));
                }

                return NotFound(new NotFoundResponse("Usuário não encontrado. Email ou senha icorreto."));
            }
            catch(Exception ex)
            {
                return StatusCode(500, InternalServerErrorResponse.InternalServerErrofactory(ex));
            }
            
        }
    }
}
