using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinalNintendoAPI.AuthorizationAndAuthentication;
using ProjetoFinalNintendoAPI.Interfaces;
using ProjetoFinalNintendoAPI.Models;

namespace ProjetoFinalNintendoAPI.Controllers
{
    [ApiController]
    [Route("login")]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly IUsersRepository _repository;
        private readonly GenerateToken _generateToken;
        private readonly IConfiguration _configuration;

        public LoginController(IUsersRepository repository, GenerateToken generateToken, IConfiguration configuration)
        {
            _repository = repository;
            _generateToken = generateToken;
            _configuration = configuration;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] Authenticate request)
        {
            var username = _configuration["UserAuthentication:login"];
            var password = _configuration["UserAuthentication:senha"];
            var user = await _repository.Get(request.Username, request.Password);
            if (username != request.Username && password != request.Password)
                return Unauthorized(new { message = "Usuário ou senha inválidos" });

            var token = _generateToken.GenerateJwt(user);
            user.Password = "";
            return Ok(new { user = user, token = token });
        }
    }
}