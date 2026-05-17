using CoreLTToeic.Application.Models.EditModels;
using CoreLTToeic.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CoreLTToeic.Application.Interfaces.IRepository
{
    public interface IAuthRepository
    {
        public Task<IdentityResult> Login(LoginEditModel loginModel);
        public Task<IdentityResult> Register(RegisterEditModel registerModel);
        Task<IdentityResult> ConfirmEmailAsync(string userId, string token);
        Task<AppUser?> GetByIdAsync(string userId);
        Task<IdentityResult> UpdateProfileAsync(string userId, UpdateProfileEditModel model);
        Task<IdentityResult> ChangePasswordAsync(string userId, string oldPassword, string newPassword);
    }
}
