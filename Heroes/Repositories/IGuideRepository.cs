using Heroes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;

namespace Heroes.Repositories
{
    public interface IGuideRepository
    {
        Task<IdentityResult> SignUp(SignupModel signupModel);
        Task<string> Login(LoginModel loginModel);

    }
}
