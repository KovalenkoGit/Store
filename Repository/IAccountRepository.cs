using Microsoft.AspNetCore.Identity;
using Store.Models;

namespace Store.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUser(UserRegistrationModel userModel);
        Task<SignInResult> PasswordSignInAsync(LoginModel loginModel);
        Task SignOutAsync();
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model);
    }
}