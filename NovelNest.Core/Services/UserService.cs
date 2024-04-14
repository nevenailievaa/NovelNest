namespace NovelNest.Core.Services
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using NovelNest.Core.Contracts;
    using NovelNest.Core.Enums;
    using NovelNest.Core.Models.QueryModels.Admin;
    using NovelNest.Core.Models.ViewModels.BookStore;
    using NovelNest.Infrastructure.Common;
    using NovelNest.Infrastructure.Data.Models.BookStores;
    using NovelNest.Infrastructure.Data.Models.Roles;
    using static NovelNest.Core.Constants.AdminConstants;

    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRepository repository;
        private readonly IPublisherService publisherService;

        public UserService(UserManager<ApplicationUser> userManager, IRepository repository, IPublisherService publisherService)
        {
            this.userManager = userManager;
            this.repository = repository;
            this.publisherService = publisherService;
        }

        public async Task<string> UserFullNameAsync(string userId)
        {
            var user = await repository.GetByIdAsync<ApplicationUser>(userId);

            return $"{user.FirstName} {user.LastName}";
        }

        public async Task<UserQueryServiceModel> AllAsync(
            string? searchTerm = null,
            UserRoleStatus roleSorting = UserRoleStatus.All,
            int currentPage = 1,
            int usersPerPage = 8)
        {
            var usersToShow = repository.AllAsReadOnly<ApplicationUser>();

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();

                usersToShow = usersToShow
                .Where(u => normalizedSearchTerm.Contains(u.FirstName.ToLower())
                || normalizedSearchTerm.Contains(u.LastName.ToLower())
                || normalizedSearchTerm.Contains(u.Email.ToLower())

                || u.FirstName.ToLower().Contains(normalizedSearchTerm)
                || u.LastName.ToLower().Contains(normalizedSearchTerm)
                || u.Email.ToLower().Contains(normalizedSearchTerm));
            }

            var currentUsers = usersToShow
                .Select(u => new UserServiceModel()
                {
                    Id = u.Id,
                    Email = u.Email,
                    FullName = $"{u.FirstName} {u.LastName}",
                    IsPublisher = publisherService.ExistsByUserIdAsync(u.Id).Result,
                    IsAdmin = userManager.IsInRoleAsync(u, AdminRole).Result
                })
                .ToList();

            if (roleSorting == UserRoleStatus.Publisher)
            {
                currentUsers = currentUsers.Where(u => u.IsPublisher).ToList();
            }
            else if (roleSorting == UserRoleStatus.Admin)
            {
                currentUsers = currentUsers.Where(u => u.IsAdmin).ToList();
            }

            var users = currentUsers
                .Skip((currentPage - 1) * usersPerPage)
                .Take(usersPerPage)
                .ToList();

            int totalUsers = currentUsers.Count();


            return new UserQueryServiceModel()
            {
                Users = users,
                TotalUsersCount = totalUsers
            };
        }

        public async Task<bool> ExistsByEmailAsync(string userEmail)
        {
            return await repository.AllAsReadOnly<ApplicationUser>().AnyAsync(u => u.Email.ToLower() == userEmail.ToLower());
        }

        public async Task<bool> ExistsByIdAsync(string userId)
        {
            return await repository.AllAsReadOnly<ApplicationUser>().AnyAsync(u => u.Id == userId);
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string userEmail)
        {
            return await repository.All<ApplicationUser>().Where(u => u.Email.ToLower() == userEmail.ToLower()).FirstOrDefaultAsync();
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string userId)
        {
            return await repository.GetByIdAsync<ApplicationUser>(userId);
        }

        public async Task<UserServiceModel> DetailsAsync(int userId)
        {
            ApplicationUser? currentUser = await repository.GetByIdAsync<ApplicationUser>(userId);

            var userDetails = new UserServiceModel()
            {
                Id = currentUser.Id,
                FullName = $"{currentUser.FirstName} {currentUser.LastName}",
                Email = currentUser.Email,
                IsPublisher = publisherService.ExistsByUserIdAsync(currentUser.Id).Result,
                IsAdmin = userManager.IsInRoleAsync(currentUser, AdminRole).Result
            };

            return userDetails;
        }

    }
}