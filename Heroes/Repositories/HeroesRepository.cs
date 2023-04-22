using Heroes.Data;
using Heroes.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace Heroes.Repositories
{
    public class HeroesRepository:IHeroesRepository
    {

        private readonly ApplicationContext _context;
        private readonly IHttpContextAccessor _httpContext;
        public HeroesRepository(ApplicationContext context, IHttpContextAccessor httpContext)
        {
            _httpContext=httpContext;
            _context = context;
        }
        public async Task<List<Hero>> GetAllHeroesAsync()
        {
            var Heroes = await _context.Heroes.ToListAsync();
            foreach(var hero in Heroes)
            Console.WriteLine(hero.Name);
            return Heroes;
        }
        public async Task<bool> AddHeroAsync(string heroName, string userId)
        {
            var hero = await _context.Heroes.FirstOrDefaultAsync(h => h.Name == heroName);
            if (hero == null || hero.guideId != null)
            {
                return false;
            }
            hero.guideId = userId;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<Hero>> GetHeroesByUserAsync(string UserId)
        {
            var heroes= await _context.Heroes.Where(h=>h.guideId==UserId).ToListAsync();
            return heroes;

        }
        public async Task<Hero>TrainHeroAsync(string heroName,string userId)
        {
            var heroes = await _context.Heroes.Where(h => h.guideId == userId).ToListAsync();
            var hero =  heroes.FirstOrDefault(h => h.Name == heroName);

            if (hero == null || heroes == null)
                return null;
            Console.WriteLine("hi");
            string formattedDate = DateTime.Today.ToString("yyyy-MM-dd");

            Random rnd = new Random();
            if (hero.amountTrainingPerDay == 5 && hero.lastTrainingDate == formattedDate)
                return null;

            if(hero.lastTrainingDate != formattedDate)
            {
                hero.amountTrainingPerDay = 0;
                hero.lastTrainingDate = formattedDate;
            }

            if (hero.amountTrainingPerDay == null)           
                hero.amountTrainingPerDay = 0;
            
            double p = (1 + rnd.NextDouble() * 0.1);
            hero.CurrentPower = hero.CurrentPower * p;
            hero.lastTrainingDate = formattedDate;
            hero.amountTrainingPerDay++;
            await _context.SaveChangesAsync();
            return hero;
        }
    }
}
