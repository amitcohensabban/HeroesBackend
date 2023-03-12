using Heroes.Data;
using Heroes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Heroes.Repositories
{
    public class GuideReopository:IGuideRepository
    {
        private readonly ApplicationContext _context;

        private readonly UserManager<Guide> _userManager;
        private readonly SignInManager<Guide> _signInManager;
        private readonly IConfiguration _configuration;

        public GuideReopository(ApplicationContext context, UserManager<Guide> userManager, SignInManager<Guide> signInManager, IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        public async Task<IdentityResult> SignUp(SignupModel signupModel)
        {
            Console.WriteLine("SignUpAction");
            Guide user = new()
            {
                Name = signupModel.FirstName,
                Email = signupModel.Email,
                UserName = signupModel.Email
            };
            var result = await _userManager.CreateAsync(user, signupModel.Password);
            await _context.SaveChangesAsync();

            return result;
        }
        public async Task<string> Login(LoginModel loginModel)
        {
            var result = await _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, false, false);
            if (!result.Succeeded)
            {
                return null;
            }
            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            string token = NewToken(loginModel.Email,user.Id);
            await _context.SaveChangesAsync();






            return token;
        }
        private string NewToken(string email,string id)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, email),
                new Claim(ClaimTypes.NameIdentifier, id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
