using CoreLTToeic.Application.Models.EditModels;
using Microsoft.AspNetCore.Identity;

namespace CoreLTToeic.Application.Interfaces.IRepository
{
    public interface IAuthRepository
    {
        public Task<IdentityResult> Login(LoginEditModel loginModel);
        public Task<IdentityResult> Register(RegisterEditModel registerModel);
        Task<IdentityResult> ConfirmEmailAsync(string userId, string token);
    }
}
