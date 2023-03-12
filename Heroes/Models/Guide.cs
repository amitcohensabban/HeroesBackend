using Microsoft.AspNetCore.Identity;

namespace Heroes.Models
{
    public class Guide : IdentityUser
    {
        public string Name { get; set; }
        public IList<Hero>? Heroes { get; set; }
        
    }
}
