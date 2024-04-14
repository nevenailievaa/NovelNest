namespace NovelNest.Core.Contracts
{
    using NovelNest.Core.Enums;
    using NovelNest.Core.Models.QueryModels.Admin;
    using NovelNest.Core.Models.ViewModels.BookStore;
    using NovelNest.Infrastructure.Data.Models.Roles;

    public interface IUserService
    {
        Task<string> UserFullNameAsync(string userId);

        Task<UserQueryServiceModel> AllAsync(
            string? searchTerm = null,
            UserRoleStatus roleSorting = UserRoleStatus.All,
            int currentPage = 1,
            int usersPerPage = 8);

        Task<bool> ExistsByIdAsync(string userId);
        Task<bool> ExistsByEmailAsync(string userEmail);
        Task<ApplicationUser> GetUserByIdAsync(string userId);
        Task<ApplicationUser> GetUserByEmailAsync(string userEmail);
        Task<UserServiceModel> DetailsAsync(int userId);
    }
}