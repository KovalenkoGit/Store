using Microsoft.AspNetCore.Identity;
using Store.Models;

namespace Store.Repository
{
    public interface IAccountRepository
    {
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task<IdentityResult> CreateUser(UserRegistrationModel userModel);
        Task<SignInResult> PasswordSignInAsync(LoginModel loginModel);
        Task SignOutAsync();
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model);
        Task<IdentityResult> ConfirmEmailAsync(string uid, string token);
        Task GenerateEmailConfirmationTokenAsyn(ApplicationUser user);
        Task GenerateForgotPasswordTokenAsyn(ApplicationUser user);
        Task<IdentityResult> ResetPasswordAsync(ResetPasswordModel model);
    }
}