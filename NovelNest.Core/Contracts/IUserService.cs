namespace NovelNest.Core.Contracts
{
    using Microsoft.AspNetCore.Identity;
    using NovelNest.Infrastructure.Data.Models.Roles;

    public interface IUserService
    {
        Task<bool> ExistsByIdAsync(string userId);
        Task<bool> ExistsByEmailAsync(string userEmail);
        Task<ApplicationUser> GetUserByIdAsync(string userId);
        Task<ApplicationUser> GetUserByEmailAsync(string userEmail);
    }
}