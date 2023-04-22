using Heroes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Heroes.Repositories;

namespace Heroes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuideController : ControllerBase
    {
        private readonly IGuideRepository _guideRepository;

        public GuideController(IGuideRepository guidetRepository)
        {
            _guideRepository = guidetRepository;
        }

        [HttpPost("")]

        public async Task<IActionResult> Signup([FromBody] SignupModel signupModel)
        {
            var res = await _guideRepository.SignUp(signupModel);
            if (res.Succeeded)
            {
                return Ok(res.Succeeded);
            }
            return Unauthorized();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel signinModel)
        {
            var res = await _guideRepository.Login(signinModel);
            if (string.IsNullOrWhiteSpace(res))
            {
                return Unauthorized();
            }
            var tokenResponse = new { token = res };
            return Ok(tokenResponse);
        }

    }
}
