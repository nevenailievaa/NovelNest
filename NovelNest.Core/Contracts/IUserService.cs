namespace NovelNest.Core.Contracts
{
    using NovelNest.Core.Models.ViewModels.Admin;
    using NovelNest.Infrastructure.Data.Models.Roles;

    public interface IUserService
    {
        Task<string> UserFullNameAsync(string userId);
        Task<IEnumerable<UserServiceModel>> AllAsync();
        Task<bool> ExistsByIdAsync(string userId);
        Task<bool> ExistsByEmailAsync(string userEmail);
        Task<ApplicationUser> GetUserByIdAsync(string userId);
        Task<ApplicationUser> GetUserByEmailAsync(string userEmail);
    }
}