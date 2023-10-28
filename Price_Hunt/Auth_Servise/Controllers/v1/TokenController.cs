using Microsoft.AspNetCore.Mvc;
using Auth_Servise.IntefaceRepository;
using Auth_Servise.Model;
using Auth_Servise.Repository;
using Microsoft.Extensions.Configuration;
using RabbitDataLibrary.Models;

namespace Auth_Servise.Controllers.v1
{
    [ApiController]
    [Route("api/v1")]
    public class TokenController : Controller
    {
        private readonly IAuthRepository _authRepository;
        private readonly ITokenRepository<Token> _tokenRepository;
        private readonly IConfiguration _configuration;
        private readonly IRabbitMQRepository _rabbitMQRepository;

        public TokenController(IAuthRepository authRepository,
                               ITokenRepository<Token> tokenRepository,
                               IConfiguration configuration,
                               IRabbitMQRepository rabbitMQRepository)
        {
            _tokenRepository = tokenRepository;
            _configuration = configuration;
            _rabbitMQRepository = rabbitMQRepository;
            _authRepository = authRepository;
        }

        [HttpGet("token/valid")]
        public async Task<IActionResult> ValidToken(string token)
        {
            try
            {
                var result = await _tokenRepository.IsActived(token);


                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("token")]
        public async Task<IActionResult> GetToken(string email,string password)
        {
            try
            {
                var result = await _tokenRepository.GetToken(email, password);


                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("token")]
        public async Task<IActionResult> CreateTokne(string email, string password)
        {
            try
            {
                var result = await _authRepository.CreateToken(email, password);


                var createUser = new UserCreatRabbit();
                createUser.Id = result.UserId;
                createUser.Token = result.UserToken;

                string host = _configuration.GetSection("Host:Name").Value;
                string exchange = _configuration.GetSection("TokenUpdate:Exchange").Value;

                _rabbitMQRepository.SendMessage<UserCreatRabbit>(createUser, host, exchange);

                return Ok(result.UserToken);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
