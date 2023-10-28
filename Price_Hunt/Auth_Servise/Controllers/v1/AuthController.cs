using Auth_Servise.Dto;
using Auth_Servise.IntefaceRepository;
using Auth_Servise.Model;
using Microsoft.AspNetCore.Mvc;
using RabbitDataLibrary.Models;

namespace Auth_Servise.Controllers.v1
{
    [ApiController]
    [Route("api/v1")]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _regestryRepository;
        private readonly IRabbitMQRepository _rabbitMQRepository;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthRepository regestryRepository,IRabbitMQRepository rabbitMQRepository ,IConfiguration configuration)
        {
            _regestryRepository = regestryRepository;
            _rabbitMQRepository = rabbitMQRepository;
            _configuration = configuration;
        }


        [HttpPost("authorization")]
        public async Task<IActionResult> Auth(UserRegestryDto user)
        {
            Token token = new Token();

            try
            {
                token = await _regestryRepository.Regestry(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var createUser = new UserCreatRabbit();
            createUser.Id = token.UserId;
            createUser.Token = token.UserToken;

            string host = _configuration.GetSection("Host:Name").Value;
            string exchange = _configuration.GetSection("UserCreate:Exchange").Value;

            _rabbitMQRepository.SendMessage<UserCreatRabbit>(createUser, host, exchange);

            return Ok(token.UserToken);
        }
    }
}
