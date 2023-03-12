using Heroes.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Heroes.Data
{
    public class ApplicationContext : IdentityDbContext<Guide>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<Hero> Heroes { get; set; }

    }
}
