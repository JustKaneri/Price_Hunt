using Auth_Servise.Dto;
using Auth_Servise.IntefaceRepository;
using Auth_Servise.Model;
using Microsoft.AspNetCore.Mvc;

namespace Auth_Servise.Controllers.v1
{
    [ApiController]
    [Route("api/v1")]
    public class AuthController : Controller
    {
        private readonly IRegestryRepository _regestryRepository;

        public AuthController(IRegestryRepository regestryRepository)
        {
            _regestryRepository = regestryRepository;
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


            

            return Ok(token);
        }
    }
}
