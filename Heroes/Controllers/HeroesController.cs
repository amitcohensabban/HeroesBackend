using Heroes.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using System.Security.Claims;



namespace Heroes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly IHeroesRepository _heroesRepository;
        public HeroesController(IHeroesRepository HeroesRepository)
        {
            _heroesRepository = HeroesRepository;
        }

        [HttpGet("")]
        [Authorize]
        public async Task<IActionResult> GetAllHeroes()
        {
            var res=await _heroesRepository.GetAllHeroesAsync();
            if (res?.Count > 0)
            {
                return Ok(res);
            }
            return BadRequest("no heroes");
        }
        [HttpPost("addHero")]
        [Authorize]
        public async Task<IActionResult> AddHero(string heroName)
        {
            string? userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            bool result = await _heroesRepository.AddHeroAsync(heroName, userId);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("users/{user}/heroes")]
        [Authorize]
        public async Task<IActionResult> GetAllHeroesOfUser()
        {
            string? userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Console.WriteLine("userId"+ userId);
            var res= await _heroesRepository.GetHeroesByUserAsync(userId);
            if (res.Count > 0)
            {
                return Ok(res);
            }
            return BadRequest("no heroes");
        }

        [HttpPatch("users/{user}/heroes/{heroName}")]
        [Authorize]
        public async Task<IActionResult>TrainHeroByName(string heroName)
        {
            string? userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var res= await _heroesRepository.TrainHeroAsync(heroName, userId);
            if (res!=null)
            {
                return Ok(res);
            }
            return BadRequest("failed to train");
        }

    }
}
