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
        private readonly IUsersRepository<UsersModel> _repository;
        private readonly GenerateToken _generateToken;
        private readonly IConfiguration _configuration;

        public LoginController(IUsersRepository<UsersModel> repository, GenerateToken generateToken, IConfiguration configuration)
        {
            _repository = repository;
            _generateToken = generateToken;
            _configuration = configuration;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] Authenticate request)
        {
            var username = _configuration["UserAuthentication:username"];
            var password = _configuration["UserAuthentication:password"];
            var user = await _repository.Get(request.Username, request.Password);
            if (username != request.Username && password != request.Password)
                return Unauthorized(new { message = "Invalid username or password" });

            var token = _generateToken.GenerateJwt(user);
            user.Password = "";
            return Ok(new { user = user, token = token });
        }
    }
}