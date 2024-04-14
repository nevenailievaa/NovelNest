namespace NovelNest.Core.Services
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using NovelNest.Core.Contracts;
    using NovelNest.Core.Models.ViewModels.Admin;
    using NovelNest.Infrastructure.Common;
    using NovelNest.Infrastructure.Data.Models.Roles;
    using System.Collections.Generic;
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

        public async Task<IEnumerable<UserServiceModel>> AllAsync()
        {
            var users = await repository.AllAsReadOnly<ApplicationUser>().ToListAsync();

            var userModels = users
                .Select(u => new UserServiceModel()
                {
                    Email = u.Email,
                    FullName = UserFullNameAsync(u.Id).Result,
                    IsPublisher = publisherService.ExistsByUserIdAsync(u.Id).Result,
                    IsAdmin = userManager.IsInRoleAsync(u, AdminRole).Result
                })
                .ToList();

            return userModels;
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
    }
}