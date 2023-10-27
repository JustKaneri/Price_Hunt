using Microsoft.AspNetCore.Mvc;
using Auth_Servise.IntefaceRepository;
using Auth_Servise.Model;

namespace Auth_Servise.Controllers.v1
{
    [ApiController]
    [Route("api/v1")]
    public class TokenController : Controller
    {
        private readonly ITokenRepository<Token> _tokenRepository;

        public TokenController(ITokenRepository<Token> tokenRepository)
        {
            _tokenRepository = tokenRepository;
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

    }
}
