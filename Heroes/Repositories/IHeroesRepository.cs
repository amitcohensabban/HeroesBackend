using Heroes.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace Heroes.Repositories
{
    public interface IHeroesRepository
    {
        Task<List<Hero>> GetAllHeroesAsync();
        Task<bool> AddHeroAsync(string heroName, string userId);
        Task <List<Hero>> GetHeroesByUserAsync(string userId);
        Task<bool> TrainHeroAsync(string heroName, string userId);

    }
}
